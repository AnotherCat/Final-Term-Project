using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ActiveableObject : MonoBehaviour {

    
    public ActiveableObject[] MustActiveObjects;

    [HideInInspector]
    public string StatusText;
    [HideInInspector]
    public bool Locked = false;
    [HideInInspector]
    public bool Activated = false;

    public bool Hold = false;
    public bool Toggle = false;

    public float Delay = 0;
    [HideInInspector]
    public bool Delaying = false;
    private bool foo = false;
    [HideInInspector]
    public float timer = 0;

    private bool holding = false;

    public virtual void ActiveObject()
    {
        if (Locked) return;
        if (Hold) return;

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

        if (Hold)
        {
            if (!Toggle && Activated) return;

            if (holding)
            {
                timer += Time.deltaTime;
            }else
            {
                timer = 0;
            }

            if (timer >= Delay)
            {
                timer = 0;
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
        else
        {
            if (foo && Delay > 0)
            {
                timer += Time.deltaTime;
                if (timer >= Delay)
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

        holding = false;
    }

    public void OnKeyDown()
    {
        holding = true;
    }
    public void OnKeyUp()
    {
        holding = false;
    }
}
