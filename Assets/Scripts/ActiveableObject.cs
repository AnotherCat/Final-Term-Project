using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ActiveableObject : MonoBehaviour {

    public bool CanActive = true;

    public abstract void ActiveObject();
}
