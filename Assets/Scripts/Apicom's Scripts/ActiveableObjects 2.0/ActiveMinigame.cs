using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ActiveMinigame : ActiveableObject20 {

    public GameObject MinigameCanvas;
    public GameObject MinigameCamera;

    private UIFps ui;

    private void Start()
    {
        MinigameCanvas.SetActive(false);
        MinigameCamera.SetActive(false);
    }

    public override void OnTriggerStay(Collider other)
    {
        ui = other.GetComponent<UIFps>();
        if (ui != null)
        {
            if (IsLock)
            {
                ui.MidText.text = "";
            }
            else
            {
                ui.MidText.text = "Press " + Press.ToString();
            }

        }
        if (Input.GetKeyDown(Press) && !IsLock)
        {
            
            Interact();
        }
    }

    public override void Interact()
    {
        ui.FreezePlayer();
        MinigameCamera.SetActive(true);
        MinigameCanvas.SetActive(true);
    }

    public void OnCorrect()
    {
        ui.UnfreezePlayer();
        MinigameCamera.SetActive(false);
        MinigameCanvas.SetActive(false);
    }
    public void OnIncorrect()
    {
        Debug.Log("Incorrect");
    }

    public override void Update()
    {
        base.Update();
        
    }
}

