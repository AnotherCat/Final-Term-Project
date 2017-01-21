using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCamera : MonoBehaviour {

    public UIFps playerScript;
    public Camera cutsceneCamera;

    public void Start()
    {
        playerScript.FreezePlayer();
        playerScript.HideCursor();
        cutsceneCamera.enabled = true;
    }

	public void OnCutsceneEnd()
    {
        playerScript.UnfreezePlayer();
        disableCutsceneCamera();
    }

    void disableCutsceneCamera()
    {
        cutsceneCamera.enabled = false;
    }

    void enableCutsceneCamera()
    {
        cutsceneCamera.enabled = true;
    }
    
}
