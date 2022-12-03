using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserAdd : MonoBehaviour
{
    [SerializeField] InputField name;
    [SerializeField] InputField id;
    [SerializeField] InputField pass;
    [SerializeField] PostSender ps;
    public void Submit()
    {
        ps.MakeUser(new UserData(name.text,pass.text,id.text));
    }
}
