using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.SceneManagement;
public class LoginChap : MonoBehaviour
{ 
    [SerializeField] InputField id;//���[�UID���̓t�H�[��
    [SerializeField] InputField pass;//�p�X���[�h���̓t�H�[��
    [SerializeField] GameObject Window;//���b�Z�[�W�E�B���h�E�̃v���n�u
    public void Submit()//���͊m��
    {
        if(id.text==""||pass.text==""){
            EndProcess("�S�Ẵe�L�X�g�{�b�N�X�ɒl����͂��Ă��������B");
            return;
        }
        PostParam[] param = {null};
        StartCoroutine(PostSender.Get("getchallenge",SendChallenge));//�R���[�`���J�n
    }
    public void SendChallenge(string chl){//�`�������W���󂯎������
        Debug.Log(chl);
        var challenge = JsonUtility.FromJson<ChallengeData>(chl);//JSON���p�[�X
        var csp = new SHA256CryptoServiceProvider();//�n�b�V�����p�N���X
        var targetBytes = Encoding.UTF8.GetBytes(pass.text);//�o�C�g�R�[�h�ɕϊ�
        var hashBytes = csp.ComputeHash(targetBytes);//�n�b�V����
        var hashStr = new StringBuilder();
        foreach (var hashByte in hashBytes) {
            hashStr.Append(hashByte.ToString("x2"));//String�ɕϊ����Ă���
        }
        targetBytes = Encoding.UTF8.GetBytes(hashStr.ToString()+challenge.chl);//�`�������W�Ƃ����t���Ă܂��o�C�g�R�[�h��
        hashBytes = csp.ComputeHash(targetBytes);//�܂��n�b�V����
        hashStr = new StringBuilder();
        foreach (var hashByte in hashBytes) {
            hashStr.Append(hashByte.ToString("x2"));//�܂�String��
        }
        PostParam[] param = { new PostParam("loginname", id.text), new PostParam("pass", hashStr.ToString()),new PostParam("code",challenge.code) };//�`�������W�̎��ʎq�ƂƂ��ɑ���t����
        StartCoroutine(PostSender.Upload(param,"login_chap",EndProcess));//�R���[�`���J�n
    }
    void EndProcess(string mes)//�������I�������
    {
        var meses=mes.Split(" ");
        GameObject go = Instantiate(Window, this.transform.parent.parent);//�E�B���h�E����
        if (meses[0] == "success")//����ɏI�������
        {
            PlayerPrefs.SetString("SID",meses[1]);
            PlayerPrefs.SetString("loginname",id.text);
            SceneManager.LoadScene(0);//�Q�[���V�[���ɑJ��
        }
        else//�G���[�Ȃ�
        {
            go.GetComponent<MessageSerializer>().SetType(2, mes);//�G���[���b�Z�[�W�o��
        }
    }
}
[System.Serializable]
public class ChallengeData{
    public string code;
    public string chl;
}
