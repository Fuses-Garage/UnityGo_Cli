using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoSerializer : MonoBehaviour//Info初期化用スクリプト
{
    //内容を表示するText
    [SerializeField] Text title;
    [SerializeField] Text about;
    [SerializeField] Text date;
    public void OshiraseSerialize(OshiraseData o)
    {
        //Dataの内容を代入
        title.text = o.TITLE;
        about.text = o.ABOUT;
        date.text = o.DATE.Substring(0,10);//日付だけを抜き出す
    }
}
