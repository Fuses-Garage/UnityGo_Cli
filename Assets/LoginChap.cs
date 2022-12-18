using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginBasic : MonoBehaviour
{
    [SerializeField] InputField id;//ユーザID入力フォーム
    [SerializeField] InputField pass;//パスワード入力フォーム
    [SerializeField] GameObject Window;//メッセージウィンドウのプレハブ
    public void Submit()//入力確定
    {
        PostParam[] param = { new PostParam("loginname", id.text), new PostParam("pass", pass.text) };
        StartCoroutine(PostSender.Upload(param,"login_basic",EndProcess));//コルーチン開始
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
