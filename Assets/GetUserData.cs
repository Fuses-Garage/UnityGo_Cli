using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class GetUserData : MonoBehaviour
{
    [SerializeField] GameObject Window;//メッセージウィンドウのプレハブ
    [SerializeField] Text uname;
    private void Start() 
    {
        if(PlayerPrefs.HasKey("SID")){
            PostParam[] param = { new PostParam("SID",PlayerPrefs.GetString("SID")) };
            StartCoroutine(PostSender.Upload(param,"getuserinfo",EndProcess));//コルーチン開始
        }
    }
    void EndProcess(string mes)//処理が終わったら
    {
        var meses=mes.Split(" ");
        if (meses[0] == "success")//正常に終了すれば
        {
            var uinfo = JsonUtility.FromJson<UserInfo>(meses[1]);//JSONをパース
            uname.text=uinfo.name;
        }
        else if(mes.Equals("login please"))//セッションエラーなら
        {
            SceneManager.LoadScene(1);//タイトルに戻る
        }else{//エラーなら
            GameObject go = Instantiate(Window, this.transform.parent.parent);//ウィンドウ生成
            go.GetComponent<MessageSerializer>().SetType(2, mes);//エラーメッセージ出力
        }
    }
}
[System.Serializable]
public class UserInfo{
    public string name;
}
