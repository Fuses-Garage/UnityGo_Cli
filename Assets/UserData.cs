using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData:Object//���[�U�o�^�f�[�^�p�N���X
{
    public PostParam[] ps = new PostParam[3];
    public UserData(string n, string p, string l)
    {
        ps[0] = new PostParam("name", n);//���[�U��
        ps[1] = new PostParam("pass", p);//�p�X���[�h
        ps[2] = new PostParam("loginname", l);//���O�C��ID
    }
}
