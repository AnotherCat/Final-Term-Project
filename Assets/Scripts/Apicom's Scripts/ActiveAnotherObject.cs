using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnotherObject : ActiveButton
{
    public ActiveableObject[] TargetObjects;

    public override void ActiveObject()
    {
        if (TargetObjects.Length == 0 || TargetObjects == null) return;

        for(int i = 0;i < TargetObjects.Length; i++)
        {
            if(TargetObjects[i].Locked == true)
            {
                TargetObjects[i].Locked = false;
            }

            TargetObjects[i].ActiveObject();
        }
    }

    public override void Update()
    {
        base.Update();
    }
}
