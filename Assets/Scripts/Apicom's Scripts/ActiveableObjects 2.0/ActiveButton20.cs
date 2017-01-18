using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton20 : ActiveableObject20 {

    public Renderer rend;
    public Color ActivatedColor;
    public Color InactivatedColor;

    public override void Interact()
    {
        if (IsToggle)
        {
            Activated = !Activated;
        }else
        {
            Activated = true;
            IsLock = true;
        }
    }

    public override void Update()
    {
        base.Update();
        StatusColor();
    }

    private void StatusColor()
    {
        if (Activated)
        {
            rend.material.color = ActivatedColor;
        }
        else
        {
            rend.material.color = InactivatedColor;
        }
    }
}
