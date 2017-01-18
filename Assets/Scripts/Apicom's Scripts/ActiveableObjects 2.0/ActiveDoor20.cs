using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDoor20 : ActiveableObject20 {

    public Animation doorAnimation;
    public UIFloating uiFloating;

    public override void Interact()
    {
        if (IsToggle)
        {
            if (Activated)
            {
                CloseAnimation();
            }else if (!Activated)
            {
                OpenAnimation();
            }
        }else
        {
            OpenAnimation();
            IsLock = true;
        }
    }

    void OpenAnimation()
    {
        if(!doorAnimation.IsPlaying("open") || !doorAnimation.IsPlaying("close"))
        {
            doorAnimation.Play("open");
            Activated = true;
        }
    }

    void CloseAnimation()
    {
        if (doorAnimation.IsPlaying("open") || doorAnimation.IsPlaying("close"))
        {
            doorAnimation.Play("close");
            Activated = false;
        }
    }

    public override void Update()
    {
        base.Update();
        if (Activated && IsLock)
        {
            uiFloating.hide();
        }else if(IsLock)
        {
            uiFloating.show();
        }else
        {
            uiFloating.hide();
        }
    }
}
