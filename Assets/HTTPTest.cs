using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class HTTPTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t;
    // Start is called before the first frame update
    public void ConnectStart()//�{�^�����쎞�ɌĂ΂��
    {
        StartCoroutine("GetResponce");//�R���[�`���J�n
    }

    IEnumerator GetResponce()//HTTP�ŕ������������Ă���
    {
        UnityWebRequest www = UnityWebRequest.Get("localhost/");//�T�[�o�[�i����̓��[�J���j�ɐڑ�
        yield return www.SendWebRequest();//���ʂ��o��܂őҋ@

        if (www.result != UnityWebRequest.Result.Success)//200����Ȃ�������
        {
            Debug.Log(www.error);//�G���[��\������
        }
        else//200�Ȃ�
        {
            t.text = www.downloadHandler.text;//������\��
        }
    }
}
