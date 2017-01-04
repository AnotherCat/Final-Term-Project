using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookFocus : MonoBehaviour {

    public Text ActiveObjectText;
    public Camera fpsCam;
    private RaycastHit hitInfo;
    public float maxDistance = 5;

    //private void FixedUpdate()
    void Update()
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.TransformDirection(Vector3.forward), out hitInfo, maxDistance))
        {
            ActiveableObject act = hitInfo.collider.GetComponent<ActiveableObject>();
            if(act != null)
            {

                ActiveObjectText.enabled = true;
                ActiveObjectText.text = act.StatusText;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    act.ActiveObject();
                }
                if (Input.GetKey(KeyCode.E))
                {
                    act.OnKeyDown();
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    act.OnKeyUp();
                }
            }
        }
        else
        {
            ActiveObjectText.text = "";
        }
    }
}
