using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    [SerializeField] int currentindex;
    void Start()
    {
        foreach(var v in panels)
        {
            v.SetActive(false);
        }
        panels[currentindex].SetActive(true);
    }

    public void SwitchPanel(int index)
    {
        panels[currentindex].SetActive(false);
        currentindex = index;
        panels[currentindex].SetActive(true);
    }
}
