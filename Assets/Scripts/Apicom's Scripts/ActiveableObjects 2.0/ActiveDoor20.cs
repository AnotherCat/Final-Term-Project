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

            if (TitleQuest != null && DescriptQuest != null)
            {
                TitleQuest.text = TitleQuestString;
                DescriptQuest.text = DescriptionQuestString;
            }
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
        if (!IsLock || Activated)
        {
            uiFloating.hide();
        }else
        {
            uiFloating.show();
        }
    }
}
