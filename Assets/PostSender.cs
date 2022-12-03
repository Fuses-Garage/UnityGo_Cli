using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using System.Threading;
using System.Threading.Tasks;
public class PostSender:MonoBehaviour//POSTリクエスト用クラス
{
    [SerializeField] string url;//送信先のURL
    public void MakeUser(UserData u) //ユーザー登録
    { 
        StartCoroutine(Upload(u.ps));

    }
    IEnumerator Upload(PostParam[] param)//送信処理
    {

        WWWForm form = new WWWForm();//newで生成
        
        foreach (PostParam p in param)//postparamの中身を1つずつ追加
        {
            form.AddField(p.key,p.val);
            Debug.Log(string.Concat("Key=",p.key,",Value=",p.val));
        }
        
        UnityWebRequest www = UnityWebRequest.Post("127.0.0.1/" + url,form);//リクエスト生成
        Debug.Log("Request Send to "+ "localhost/" + url);
        yield return www.SendWebRequest();//送信
        Debug.Log(www.downloadHandler.text);
        if (www.result != UnityWebRequest.Result.Success)//成功したかで分岐
        {
            
            yield return www.downloadHandler.text;//結果を出力
        }
        else
        {
            yield return www.downloadHandler.text;//エラーを出力
        }
    }

}

