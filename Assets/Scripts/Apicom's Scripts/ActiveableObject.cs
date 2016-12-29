using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ActiveableObject : MonoBehaviour {

    
    public ActiveableObject[] MustActiveObjects;

    [HideInInspector]
    public string StatusText;
    
    public bool Locked = false;
    public bool Activated = false;
    public bool Toggle = false;

    public virtual void ActiveObject()
    {
        if (Locked) return;

        if (Toggle)
        {
            Activated = !Activated;
        }
        else
        {
            Activated = true;
        }
        
    }

    public virtual void Update()
    {
        if(MustActiveObjects.Length > 0 && MustActiveObjects != null)
        {
            Locked = false;
            for(int i = 0; i < MustActiveObjects.Length; i++)
            {
                if (!MustActiveObjects[i].Activated)
                {
                    Locked = true;
                    break;
                }
            }
        }
    }
}
