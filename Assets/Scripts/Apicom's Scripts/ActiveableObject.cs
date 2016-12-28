using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ActiveableObject : MonoBehaviour {

    
    public ActiveableObject[] MustActiveObjects;

    [HideInInspector]
    public string StatusText;
    
    public bool Toggle = true;
    public bool Activated = false;

    public abstract void ActiveObject();

    public virtual void Update()
    {
        if(MustActiveObjects.Length > 0 && MustActiveObjects != null)
        {
            Toggle = true;
            for(int i = 0; i < MustActiveObjects.Length; i++)
            {
                if (!MustActiveObjects[i].Activated)
                {
                    Toggle = false;
                    break;
                }
            }
        }
    }
}
