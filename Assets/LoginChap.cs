using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;
public class LoginChap : MonoBehaviour
{ 
    [SerializeField] InputField id;//ユーザID入力フォーム
    [SerializeField] InputField pass;//パスワード入力フォーム
    [SerializeField] GameObject Window;//メッセージウィンドウのプレハブ
    public void Submit()//入力確定
    {
        if(id.text==""||pass.text==""){
            EndProcess("全てのテキストボックスに値を入力してください。");
            return;
        }
        PostParam[] param = {null};
        StartCoroutine(PostSender.Get("getchallenge",SendChallenge));//コルーチン開始
    }
    public void SendChallenge(string chl){//チャレンジを受け取ったら
        Debug.Log(chl);
        var challenge = JsonUtility.FromJson<ChallengeData>(chl);//JSONをパース
        var csp = new SHA256CryptoServiceProvider();//ハッシュ化用クラス
        var targetBytes = Encoding.UTF8.GetBytes(pass.text);//バイトコードに変換
        var hashBytes = csp.ComputeHash(targetBytes);//ハッシュ化
        var hashStr = new StringBuilder();
        foreach (var hashByte in hashBytes) {
            hashStr.Append(hashByte.ToString("x2"));//Stringに変換していく
        }
        targetBytes = Encoding.UTF8.GetBytes(hashStr.ToString()+challenge.chl);//チャレンジとくっ付けてまたバイトコード化
        hashBytes = csp.ComputeHash(targetBytes);//またハッシュ化
        hashStr = new StringBuilder();
        foreach (var hashByte in hashBytes) {
            hashStr.Append(hashByte.ToString("x2"));//またString化
        }
        PostParam[] param = { new PostParam("loginname", id.text), new PostParam("pass", hashStr.ToString()),new PostParam("code",challenge.code) };//チャレンジの識別子とともに送り付ける
        StartCoroutine(PostSender.Upload(param,"login_chap",EndProcess));//コルーチン開始
    }
    void EndProcess(string mes)//処理が終わったら
    {
        var meses=mes.Split(" ");
        GameObject go = Instantiate(Window, this.transform.parent.parent);//ウィンドウ生成
        if (meses[0] == "success")//正常に終了すれば
        {
            PlayerPrefs.SetString("SID",meses[1]);
            PlayerPrefs.SetString("loginname",id.text);
            SceneManager.LoadScene(0);//ゲームシーンに遷移
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
