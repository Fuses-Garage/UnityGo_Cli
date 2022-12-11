using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoSerializer : MonoBehaviour//Info�������p�X�N���v�g
{
    [SerializeField] Text title; //�^�C�g����\������Text
    [SerializeField] Text about; //���e��\������Text
    [SerializeField] Text date;  //�쐬����\������Text
    public void OshiraseSerialize(OshiraseData o)
    {
        //Data�̓��e����
        title.text = o.TITLE;
        about.text = o.ABOUT;
        date.text = o.DATE.Substring(0,10);//���t�����𔲂��o��
    }
}
