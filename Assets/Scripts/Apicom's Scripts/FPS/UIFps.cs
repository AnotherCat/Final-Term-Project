using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UIFps : MonoBehaviour {

    public Text MidText;

    public CharacterController cc;
    public FirstPersonController fps;
    public Camera cam;

    public void FreezePlayer()
    {
        cc.enabled = false;
        fps.enabled = false;
        cam.enabled = false;
    }

    public void UnfreezePlayer()
    {
        cc.enabled = true;
        fps.enabled = true;
        cam.enabled = true;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
