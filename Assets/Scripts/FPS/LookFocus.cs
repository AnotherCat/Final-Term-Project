using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookFocus : MonoBehaviour {

    public Text ActiveObjectText;
    public Camera fpsCam;
    private RaycastHit hitInfo;
    public float maxDistance = 3;

    private void FixedUpdate()
    {
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.TransformDirection(Vector3.forward) * maxDistance);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.TransformDirection(Vector3.forward), out hitInfo, maxDistance))
        {
            ActiveableObject act = hitInfo.collider.GetComponent<ActiveableObject>();
            if(act != null)
            {
                if (act.CanActive)
                {
                    ActiveObjectText.enabled = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        act.ActiveObject();
                    }

                }else
                {
                    ActiveObjectText.enabled = false;
                }
            }
        }
        else
        {
            ActiveObjectText.enabled = false;
        }
    }
}
