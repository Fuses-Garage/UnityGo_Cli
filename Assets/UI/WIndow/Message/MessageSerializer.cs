using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageSerializer : MonoBehaviour
{
    [SerializeField] DialogData[] types= { new DialogData("成功",Color.green), new DialogData("警告", Color.yellow) , new DialogData("エラー", Color.red) };
    [SerializeField] Text t;//本文
    [SerializeField] Text titlet;//タイトル
    [SerializeField] Image i1;//ダイアログ用画像
    [SerializeField] Image i2;//ダイアログ用画像
    public void SetType(int i,string text)
    {
        if (i >= 0 && types.Length > i)
        {
            t.text = text;
            titlet.text = types[i].title;
            i1.color = types[i].col;
            i2.color = types[i].col;
        }
        else
        {
            SetType(2,"タイプの値が範囲外です");
        }
    }
}
class DialogData
{
    public string title;
    public Color32 col;
    public DialogData(string t, Color32 c)
    {
        title = t;
        col = c;
    }
}