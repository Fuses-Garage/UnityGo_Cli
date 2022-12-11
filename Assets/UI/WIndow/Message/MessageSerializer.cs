using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MessageSerializer : MonoBehaviour
{
    [SerializeField] DialogData[] types= { new DialogData("����",Color.green), new DialogData("�x��", Color.yellow) , new DialogData("�G���[", Color.red) };
    [SerializeField] Text t;//�{��
    [SerializeField] Text titlet;//�^�C�g��
    [SerializeField] Image i1;//�_�C�A���O�p�摜
    [SerializeField] Image i2;//�_�C�A���O�p�摜
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
            SetType(2,"�^�C�v�̒l���͈͊O�ł�");
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