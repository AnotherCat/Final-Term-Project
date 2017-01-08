using System;
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

        if (Toggle)
        {
            if (opened)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
        else
        {
            if(!opened)
            OpenDoor();
        }
        
    }

    void OpenDoor()
    {
        doorAnimation.Play("open");
        opened = true;
        Activated = true;
    }
    void CloseDoor()
    {
        doorAnimation.Play("close");
        opened = false;
        Activated = true;
    }
    
    public override void Update()
    {
        base.Update();

        if (Locked)
        {
            StatusText = LockedText;
        }else
        {
            if (Toggle)
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
            else
            {
                if (!opened)
                {
                    CanActive = true;
                    StatusText = ActiveableText;
                }else
                {
                    CanActive = false;
                    StatusText = InactivealbeText;
                }
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
