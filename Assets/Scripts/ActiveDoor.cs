using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDoor : ActiveableObject
{

    public bool opened = false;
    
    public Animation doorAnimation;

    public override void ActiveObject()
    {
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

    private void Update()
    {

        if (doorAnimation.IsPlaying("open"))
        {
            CanActive = false;
        }

        if (doorAnimation.IsPlaying("close"))
        {
            CanActive = false;
        }
    }

}
