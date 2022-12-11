using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
public static class PostSender//POSTリクエスト用クラス
{
    [SerializeField] static int limittime=1;
    
    public static IEnumerator Upload(PostParam[] param, string url,UnityAction<string> s)//送信処理
    {

        WWWForm form = new WWWForm();//newで生成
        
        foreach (PostParam p in param)//postparamの中身を1つずつ追加
        {
            form.AddField(p.key,p.val);
            Debug.Log(string.Concat("Key=",p.key,",Value=",p.val));
        }

        using (UnityWebRequest www = UnityWebRequest.Post("127.0.0.1/" + url, form))
        {//リクエスト生成
            Debug.Log("Request Send to " + "localhost/" + url);
            www.timeout = 3;
            yield return www.Send();//送信
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Request Return");
            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                // レスポンスコードを見て処理
                s.Invoke($"[Error]Response Code : {www.responseCode}");
            }
            else if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                // エラーメッセージを見て処理
                s.Invoke($"[Error]Message : {www.error}");
            }
            else
            {
                s.Invoke(www.downloadHandler.text);
            }
        }
    }

}

