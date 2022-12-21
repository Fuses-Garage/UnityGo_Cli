using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class GetUserData : MonoBehaviour
{
    [SerializeField] GameObject Window;//���b�Z�[�W�E�B���h�E�̃v���n�u
    [SerializeField] Text uname;
    private void Start() 
    {
        if(PlayerPrefs.HasKey("SID")){
            PostParam[] param = { new PostParam("SID",PlayerPrefs.GetString("SID")) };
            StartCoroutine(PostSender.Upload(param,"getuserinfo",EndProcess));//�R���[�`���J�n
        }
    }
    void EndProcess(string mes)//�������I�������
    {
        var meses=mes.Split(" ");
        if (meses[0] == "success")//����ɏI�������
        {
            var uinfo = JsonUtility.FromJson<UserInfo>(meses[1]);//JSON���p�[�X
            uname.text=uinfo.name;
        }
        else if(mes.Equals("login please"))//�Z�b�V�����G���[�Ȃ�
        {
            SceneManager.LoadScene(1);//�^�C�g���ɖ߂�
        }else{//�G���[�Ȃ�
            GameObject go = Instantiate(Window, this.transform.parent.parent);//�E�B���h�E����
            go.GetComponent<MessageSerializer>().SetType(2, mes);//�G���[���b�Z�[�W�o��
        }
    }
}
[System.Serializable]
public class UserInfo{
    public string name;
}
