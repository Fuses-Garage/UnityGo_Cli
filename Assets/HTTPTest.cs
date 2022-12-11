using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class HTTPTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t;
    // Start is called before the first frame update
    public virtual void ConnectStart()//ボタン操作時に呼ばれる
    {
        StartCoroutine(Connect(""));//コルーチン開始
    }

    IEnumerator Connect(string url)//HTTPで文字列をもらってくる
    {
        using (UnityWebRequest www = UnityWebRequest.Get("127.0.0.1/" + url))
        {//サーバー（今回はローカル）に接続
            yield return www.SendWebRequest();//結果が出るまで待機

            if (www.result != UnityWebRequest.Result.Success)//200じゃなかったら
            {
                Debug.Log(www.error);//エラーを表示する
            }
            else//200なら
            {
                t.text = www.downloadHandler.text;//文字列表示
            }
        }
    }
}
