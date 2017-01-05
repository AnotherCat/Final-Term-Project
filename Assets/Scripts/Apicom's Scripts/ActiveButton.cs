using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButton : ActiveableObject
{
    public string LockedText = "";
    public string ActiveableText = "";
    public string PresentText = "";
    public string DelayingText = "";
    public Color ActivatedColor;
    public Color UnactivatedColor;

    public Text StateText;
    public Slider SliderDelaying;

    public override void Update()
    {
        base.Update();

        if (Locked)
        {
            StatusText = LockedText;
        }
        else
        {
            if (!Activated || Toggle)
            {
                //StatusText = ActiveableText;
                if (Delaying)
                {
                    StatusText = DelayingText;
                }else
                {
                    StatusText = ActiveableText;
                }
            }
            else
            {
                StatusText = "";
            }
        }
        if(StateText != null)
        {
            if (!Locked)
            {
                if (!Activated || Toggle)
                {
                    StateText.text = PresentText;
                }
                else
                {
                    StateText.text = "";
                }
            }else
            {
                StateText.text = "";
            }
        }
        
        StatusColor();

        if(Delay > 0 && SliderDelaying != null)
        {
            if (Delaying)
            {
                SliderDelaying.gameObject.SetActive(true);
                SliderDelaying.value = (timer / Delay) * 100;
            }
            else
            {
                SliderDelaying.gameObject.SetActive(false);
            }
        }
    }

    private void StatusColor()
    {
        if (Activated)
        {
            GetComponent<Renderer>().material.color = ActivatedColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = UnactivatedColor;
        }
    }
}
