using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.Threading;
using System.Threading.Tasks;
public static class PostSender//POST���N�G�X�g�p�N���X
{
    [SerializeField] static int limittime=1;
    
    public static IEnumerator Upload(PostParam[] param, string url,UnityAction<string> s)//���M����
    {

        WWWForm form = new WWWForm();//new�Ő���
        
        foreach (PostParam p in param)//postparam�̒��g��1���ǉ�
        {
            form.AddField(p.key,p.val);
            Debug.Log(string.Concat("Key=",p.key,",Value=",p.val));
        }

        using (UnityWebRequest www = UnityWebRequest.Post("127.0.0.1/" + url, form))
        {//���N�G�X�g����
            Debug.Log("Request Send to " + "localhost/" + url);
            www.timeout = 3;
            yield return www.Send();//���M
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Request Return");
            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                // ���X�|���X�R�[�h�����ď���
                s.Invoke($"[Error]Response Code : {www.responseCode}");
            }
            else if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                // �G���[���b�Z�[�W�����ď���
                s.Invoke($"[Error]Message : {www.error}");
            }
            else
            {
                s.Invoke(www.downloadHandler.text);
            }
        }
    }

}

