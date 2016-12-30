using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButton : ActiveableObject
{
    public string LockedText = "";
    public string ActiveableText = "";

    public Text StateText;

    public override void Update()
    {
        base.Update();

        if (Locked)
        {
            StatusText = LockedText;
        }
        else
        {
            if(!Activated || Toggle)
            {
                StatusText = ActiveableText;
            }else
            {
                StatusText = "";
            }
        }
        if(StateText != null)
        {
            if (!Locked)
            {
                if (!Activated || Toggle)
                {
                    StateText.text = "Click Here";
                }
                else
                {
                    StateText.text = "";
                }
            }else
            {
                StateText.text = "";
            }
        }
        
        StatusColor();
    }

    private void StatusColor()
    {
        if (Activated)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
