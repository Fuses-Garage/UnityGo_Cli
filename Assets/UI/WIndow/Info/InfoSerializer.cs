using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoSerializer : MonoBehaviour//Info初期化用スクリプト
{
    [SerializeField] Text title; //タイトルを表示するText
    [SerializeField] Text about; //内容を表示するText
    [SerializeField] Text date;  //作成日を表示するText
    public void OshiraseSerialize(OshiraseData o)
    {
        //Dataの内容を代入
        title.text = o.TITLE;
        about.text = o.ABOUT;
        date.text = o.DATE.Substring(0,10);//日付だけを抜き出す
    }
}
