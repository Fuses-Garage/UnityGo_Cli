using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoWindow : MonoBehaviour
{
    [SerializeField] GameObject contents;//���m�点���o���ʒu
    [SerializeField] GameObject InfoPanel;//���m�点�p�l��
    public void InfoAdd(OshiraseData[] ods)
    {
        foreach (var v in ods)//����
        {
            GameObject go = Instantiate(InfoPanel,contents.transform);//�e���w�肵�Đ���
            go.GetComponent<InfoSerializer>().OshiraseSerialize(v);//���m�点�̓��e��n��
        }
    }
}
