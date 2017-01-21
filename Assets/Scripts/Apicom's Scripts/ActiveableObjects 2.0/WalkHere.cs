using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkHere : ActiveableObject20 {

    public UIFloating uiFloating;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player") && !IsLock) // player in range
        {
            Interact();
        }
    }

    public override void OnTriggerStay(Collider other)
    {
        // do nothing
    }

    public override void Interact()
    {
        Activated = true;
        IsLock = true;

        if (TitleQuest != null && DescriptQuest != null)
        {
            TitleQuest.text = TitleQuestString;
            DescriptQuest.text = DescriptionQuestString;
        }
    }

    public override void Update()
    {
        base.Update();


        if (uiFloating == null) return;

        if(Activated || IsLock)
        {
            uiFloating.hide();
        }else
        {
            uiFloating.show();
        }
    }
}
