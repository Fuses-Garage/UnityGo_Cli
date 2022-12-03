using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostParam//Postパラメータ用クラス
{
    public PostParam(string k, string v)
    {
        key = k;
        val = v;
    }
    public string key;
    public string val;
}
