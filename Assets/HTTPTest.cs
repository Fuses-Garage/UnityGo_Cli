using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
public class HTTPTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t;
    // Start is called before the first frame update
    public virtual void ConnectStart()//�{�^�����쎞�ɌĂ΂��
    {
        StartCoroutine(Connect(""));//�R���[�`���J�n
    }

    IEnumerator Connect(string url)//HTTP�ŕ������������Ă���
    {
        using (UnityWebRequest www = UnityWebRequest.Get("127.0.0.1/" + url))
        {//�T�[�o�[�i����̓��[�J���j�ɐڑ�
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
}
