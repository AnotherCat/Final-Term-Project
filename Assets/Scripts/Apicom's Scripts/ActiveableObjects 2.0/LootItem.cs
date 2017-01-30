using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : ActiveableObject20 {

    public GameObject[] ItemGameObjects;
    public int Gain_S = 0;
    public int Gain_T = 0;
    public int Gain_E = 0;
    public int Gain_M = 0;

    public override void Interact()
    {
        if(ItemGameObjects != null && ItemGameObjects.Length > 0)
        {
            foreach(GameObject g in ItemGameObjects)
            {
                g.GetComponent<Renderer>().enabled = false;
            }
        }
        Activated = true;

        GameManager.GM.S += Gain_S;
        GameManager.GM.T += Gain_T;
        GameManager.GM.E += Gain_E;
        GameManager.GM.M += Gain_M;
        GameManager.GM.RefreshUI();
    }
}
