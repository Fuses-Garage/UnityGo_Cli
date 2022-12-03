using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using System.Threading;
using System.Threading.Tasks;
public class PostSender:MonoBehaviour//POST���N�G�X�g�p�N���X
{
    [SerializeField] string url;//���M���URL
    public void MakeUser(UserData u) //���[�U�[�o�^
    { 
        StartCoroutine(Upload(u.ps));

    }
    IEnumerator Upload(PostParam[] param)//���M����
    {

        WWWForm form = new WWWForm();//new�Ő���
        
        foreach (PostParam p in param)//postparam�̒��g��1���ǉ�
        {
            form.AddField(p.key,p.val);
            Debug.Log(string.Concat("Key=",p.key,",Value=",p.val));
        }
        
        UnityWebRequest www = UnityWebRequest.Post("127.0.0.1/" + url,form);//���N�G�X�g����
        Debug.Log("Request Send to "+ "localhost/" + url);
        yield return www.SendWebRequest();//���M
        Debug.Log(www.downloadHandler.text);
        if (www.result != UnityWebRequest.Result.Success)//�����������ŕ���
        {
            
            yield return www.downloadHandler.text;//���ʂ��o��
        }
        else
        {
            yield return www.downloadHandler.text;//�G���[���o��
        }
    }

}

