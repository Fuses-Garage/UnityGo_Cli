using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginBasic : MonoBehaviour
{
    [SerializeField] InputField id;//���[�UID���̓t�H�[��
    [SerializeField] InputField pass;//�p�X���[�h���̓t�H�[��
    [SerializeField] GameObject Window;//���b�Z�[�W�E�B���h�E�̃v���n�u
    public void Submit()//���͊m��
    {
        PostParam[] param = { new PostParam("loginname", id.text), new PostParam("pass", pass.text) };
        StartCoroutine(PostSender.Upload(param,"login_basic",EndProcess));//�R���[�`���J�n
    }
    void EndProcess(string mes)//�������I�������
    {
        GameObject go = Instantiate(Window, this.transform.parent.parent);//�E�B���h�E����
        if (mes == "success")//����ɏI�������
        {
            go.GetComponent<MessageSerializer>().SetType(0, "���O�C���ɐ������܂����I");//����
        }
        else//�G���[�Ȃ�
        {
            go.GetComponent<MessageSerializer>().SetType(2, mes);//�G���[���b�Z�[�W�o��
        }
    }
}
