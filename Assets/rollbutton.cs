using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rollbutton : MonoBehaviour
{
    public Canvas cnv;
    public Camera cmr1;
    public Camera cmr2;
    void Update()
    {
        if (Moving.count == 0 && cmr1.enabled == true)
            cnv.enabled = true;
        else
            cnv.enabled = false;
    }

    public void Roll()
    {
        cmr2.enabled = true;
        cmr1.enabled = false;
    }
    public void change()
    {
        cmr1.enabled = true;
        cmr2.enabled = false;
    }
}
