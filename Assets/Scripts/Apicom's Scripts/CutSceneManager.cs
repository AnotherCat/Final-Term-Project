using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CutSceneManager : MonoBehaviour {

    public Camera FPSCamera;
    public Animator CutSceneCameraAnimator;

    public CharacterController cc;
    public FirstPersonController fpc;

    private void Start()
    {
        playCutScene("WakeUp",9.5f);
    }

    public void playCutScene(string triggerAnimationVariable,float t)
    {
        FPSCamera.enabled = false;
        if(CutSceneCameraAnimator != null)
        {
            CutSceneCameraAnimator.SetBool("ActiveCutSceneCamera", true);
            CutSceneCameraAnimator.SetTrigger(triggerAnimationVariable);
            Invoke("OnTimeout", t);
        }
    }
    void OnTimeout()
    {
        CutSceneCameraAnimator.SetBool("ActiveCutSceneCamera", false);
        FPSCamera.enabled = true;
        cc.enabled = true;
        fpc.enabled = true;
    }
}
