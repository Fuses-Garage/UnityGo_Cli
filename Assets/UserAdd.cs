using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserAdd : MonoBehaviour
{
    [SerializeField] InputField uname;//ユーザ名用入力フォーム
    [SerializeField] InputField id;//ユーザID入力フォーム
    [SerializeField] InputField pass;//パスワード入力フォーム
    [SerializeField] GameObject Window;//メッセージウィンドウのプレハブ
    public void Submit()//入力確定
    {
        UserData u= new UserData(uname.text, pass.text, id.text);
        StartCoroutine(PostSender.Upload(u.ps,"useradd",EndProcess));//コルーチン開始
    }
    void EndProcess(string mes)//処理が終わったら
    {
        GameObject go = Instantiate(Window, this.transform.parent.parent);//ウィンドウ生成
        if (mes == "success")//正常に終了すれば
        {
            go.GetComponent<MessageSerializer>().SetType(0, "ユーザー登録に成功しました！");//成功
        }
        else//エラーなら
        {
            go.GetComponent<MessageSerializer>().SetType(2, mes);//エラーメッセージ出力
        }
    }
}
