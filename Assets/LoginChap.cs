using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
public class LoginChap : MonoBehaviour
{ 
    [SerializeField] InputField id;//ユーザID入力フォーム
    [SerializeField] InputField pass;//パスワード入力フォーム
    [SerializeField] GameObject Window;//メッセージウィンドウのプレハブ
    public void Submit()//入力確定
    {

        PostParam[] param = {null};
        StartCoroutine(PostSender.Get("getchallenge",SendChallenge));//コルーチン開始
    }
    public void SendChallenge(string chl){
        Debug.Log(chl);
        var challenge = JsonUtility.FromJson<ChallengeData>(chl);//JSONをパース
        var csp = new SHA256CryptoServiceProvider();
        var targetBytes = Encoding.UTF8.GetBytes(pass.text);
        var hashBytes = csp.ComputeHash(targetBytes);
        var hashStr = new StringBuilder();
        foreach (var hashByte in hashBytes) {
            hashStr.Append(hashByte.ToString("x2"));
        }
        targetBytes = Encoding.UTF8.GetBytes(hashStr.ToString()+challenge.chl);
        hashBytes = csp.ComputeHash(targetBytes);
        hashStr = new StringBuilder();
        foreach (var hashByte in hashBytes) {
            hashStr.Append(hashByte.ToString("x2"));
        }
        PostParam[] param = { new PostParam("loginname", id.text), new PostParam("pass", hashStr.ToString()),new PostParam("code",challenge.code) };
        StartCoroutine(PostSender.Upload(param,"login_chap",EndProcess));//コルーチン開始
    }
    void EndProcess(string mes)//処理が終わったら
    {
        GameObject go = Instantiate(Window, this.transform.parent.parent);//ウィンドウ生成
        if (mes == "success")//正常に終了すれば
        {
            go.GetComponent<MessageSerializer>().SetType(0, "ログインに成功しました！");//成功
        }
        else//エラーなら
        {
            go.GetComponent<MessageSerializer>().SetType(2, mes);//エラーメッセージ出力
        }
    }
}
[System.Serializable]
public class ChallengeData{
    public string code;
    public string chl;
}
