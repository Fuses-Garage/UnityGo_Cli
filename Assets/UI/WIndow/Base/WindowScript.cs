using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScript : MonoBehaviour
{
    public void DestroyWindow()
    {
        Destroy(this.gameObject);
    }
}
