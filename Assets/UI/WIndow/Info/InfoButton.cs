using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class InfoButton : MonoBehaviour
{
    [SerializeField] GameObject window;//お知らせウィンドウ
    // Start is called before the first frame update
    public virtual void ConnectStart()//ボタン操作時に呼ばれる
    {
        StartCoroutine(Connect());//コルーチン開始
    }

    IEnumerator Connect()//HTTPで文字列をもらってくる
    {
        UnityWebRequest www = UnityWebRequest.Get("localhost/getinfo");//サーバー（今回はローカル）に接続
        yield return www.SendWebRequest();//結果が出るまで待機

        if (www.result != UnityWebRequest.Result.Success)//200じゃなかったら
        {
            Debug.Log(www.error);//エラーを表示する
        }
        else//200なら
        {
            
            var wrapper = JsonUtility.FromJson<OshiraseWrapper>("{\"osrs\":"+www.downloadHandler.text+"}");//JSONをラッパーに
            var go=Instantiate(window);//ウィンドウ生成
            go.GetComponent<InfoWindow>().InfoAdd(wrapper.osrs);//ウィンドウに渡す
        }
    }
}
