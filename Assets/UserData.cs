using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData:Object//ユーザ登録データ用クラス
{
    public PostParam[] ps = new PostParam[3];
    public UserData(string n, string p, string l)
    {
        ps[0] = new PostParam("name", n);//ユーザ名
        ps[1] = new PostParam("pass", p);//パスワード
        ps[2] = new PostParam("loginname", l);//ログインID
    }
}
