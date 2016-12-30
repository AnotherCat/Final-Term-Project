﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveDoor : ActiveableObject
{

    public string LockedText = "";
    public string ActiveableText = "";
    public string InactivealbeText = "";

    public Text StateText;

    private bool opened = false;

    [HideInInspector]
    public bool CanActive = true;
    public Animation doorAnimation;

    public override void ActiveObject()
    {
        if (Locked || !CanActive) return;

        if (opened)
        {
            CloseDoor();
        }else
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        doorAnimation.Play("open");
        opened = true;
    }
    void CloseDoor()
    {
        doorAnimation.Play("close");
        opened = false;
    }
    
    public override void Update()
    {
        base.Update();

        if (Locked)
        {
            StatusText = LockedText;
        }else
        {
            if (doorAnimation.IsPlaying("open") || doorAnimation.IsPlaying("close"))
            {
                CanActive = false;
                StatusText = InactivealbeText;
            }
            else
            {
                CanActive = true;
                StatusText = ActiveableText;
            }
        }

        if(StateText != null)
        {
            if (Locked)
            {
                StateText.text = "Locked";
            }else
            {
                StateText.text = "";
            }
        }
    }
}
