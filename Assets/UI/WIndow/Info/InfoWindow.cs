using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoWindow : MonoBehaviour
{
    [SerializeField] GameObject contents;//お知らせを出す位置
    [SerializeField] GameObject InfoPanel;//お知らせパネル
    public void InfoAdd(OshiraseData[] ods)
    {
        foreach (var v in ods)//分回す
        {
            GameObject go = Instantiate(InfoPanel,contents.transform);//親を指定して生成
            go.GetComponent<InfoSerializer>().OshiraseSerialize(v);//お知らせの内容を渡す
        }
    }
}
