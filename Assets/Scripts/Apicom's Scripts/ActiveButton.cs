using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : ActiveableObject
{
    public string LockedText = "";
    public string ActiveableText = "";

    public override void ActiveObject()
    {
        if (!Toggle) return;

        Activated = !Activated;
    }

    public override void Update()
    {
        base.Update();

        if (!Toggle)
        {
            StatusText = LockedText;
        }
        else
        {
            StatusText = ActiveableText;
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
