using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFocus : MonoBehaviour {

    public Camera fpsCam;
    private RaycastHit hitInfo;
    public float maxDistance = 3;

    private void FixedUpdate()
    {
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.TransformDirection(Vector3.forward), out hitInfo, maxDistance))
        {
            if(hitInfo.collider != null && hitInfo.collider.tag.Contains("Outlined_Shadder"))
            {

            }
        }
    }
}
