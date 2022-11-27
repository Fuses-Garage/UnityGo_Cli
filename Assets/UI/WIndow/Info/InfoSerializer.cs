using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoSerializer : MonoBehaviour//Info�������p�X�N���v�g
{
    //���e��\������Text
    [SerializeField] Text title;
    [SerializeField] Text about;
    [SerializeField] Text date;
    public void OshiraseSerialize(OshiraseData o)
    {
        //Data�̓��e����
        title.text = o.TITLE;
        about.text = o.ABOUT;
        date.text = o.DATE.Substring(0,10);//���t�����𔲂��o��
    }
}
