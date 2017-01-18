using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkHere : ActiveableObject20 {

    public UIFloating uiFloating;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player")) // player in range
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
    }

    public override void Update()
    {
        base.Update();

        if (!Activated)
        {
            uiFloating.show();
        }else
        {
            uiFloating.hide();
        }
    }
}
