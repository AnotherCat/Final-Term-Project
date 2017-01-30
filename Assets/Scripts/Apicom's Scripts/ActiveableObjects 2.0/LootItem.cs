using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : ActiveableObject20 {

    public GameObject[] ItemGameObjects;
    public int Battery = 0;
    public int Wrench = 0;
    public string stringNameItem = "";

    public override void Interact()
    {
        if(ItemGameObjects != null && ItemGameObjects.Length > 0)
        {
            foreach(GameObject g in ItemGameObjects)
            {
                Renderer r = g.GetComponent<Renderer>();
                if(r != null)
                {
                    r.enabled = false;
                }else
                {
                    Renderer[] rs = g.GetComponentsInChildren<Renderer>();
                    foreach(Renderer rrr in rs)
                    {
                        rrr.enabled = false;
                    }
                }
            }
        }
        Activated = true;

        GameManager.GM.Battery += Battery;
        GameManager.GM.Wrench += Wrench;
        GameManager.GM.RefreshUI();
    }

    public override string playerText()
    {
        string str = "";
        if(Battery > 0)
        {
            str = "" + Battery;
        }
        if (Wrench > 0)
        {
            str = "" + Wrench;
        }
        return stringNameItem + " x " + str;
    }
}
