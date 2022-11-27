using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class InfoButton : MonoBehaviour
{
    [SerializeField] GameObject window;//���m�点�E�B���h�E
    // Start is called before the first frame update
    public virtual void ConnectStart()//�{�^�����쎞�ɌĂ΂��
    {
        StartCoroutine(Connect());//�R���[�`���J�n
    }

    IEnumerator Connect()//HTTP�ŕ������������Ă���
    {
        UnityWebRequest www = UnityWebRequest.Get("localhost/getinfo");//�T�[�o�[�i����̓��[�J���j�ɐڑ�
        yield return www.SendWebRequest();//���ʂ��o��܂őҋ@

        if (www.result != UnityWebRequest.Result.Success)//200����Ȃ�������
        {
            Debug.Log(www.error);//�G���[��\������
        }
        else//200�Ȃ�
        {
            
            var wrapper = JsonUtility.FromJson<OshiraseWrapper>("{\"osrs\":"+www.downloadHandler.text+"}");//JSON�����b�p�[��
            var go=Instantiate(window);//�E�B���h�E����
            go.GetComponent<InfoWindow>().InfoAdd(wrapper.osrs);//�E�B���h�E�ɓn��
        }
    }
}
