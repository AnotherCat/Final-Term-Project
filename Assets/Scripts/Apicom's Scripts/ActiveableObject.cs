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

    public float Delay = 0;
    [HideInInspector]
    public bool Delaying = false;
    private bool foo = false;
    private float timer = 0;

    public virtual void ActiveObject()
    {
        if (Locked) return;

        if (Toggle)
        {
            if(Delay > 0)
            {
                if (!Delaying)
                {
                    foo = true;
                    Delaying = true;
                }
            }else
            {
                Activated = !Activated;
            }
        }
        else
        {
            if(Delay > 0)
            {
                if (!Delaying)
                {
                    foo = true;
                    Delaying = true;
                }
            }
            else
            {
                Activated = true;
            }
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

        if(foo && Delay > 0)
        {
            timer += Time.deltaTime;
            if(timer >= Delay)
            {
                timer = 0;
                foo = false;
                Delaying = false;
                if (Toggle)
                {
                    Activated = !Activated;
                }
                else
                {
                    Activated = true;
                }
            }
        }
    }
}
