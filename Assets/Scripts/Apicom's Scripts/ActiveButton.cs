﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButton : ActiveableObject
{
    public string LockedText = "";
    public string ActiveableText = "";
    public string PresentText = "";

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
                    StatusText = "...";
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
        SliderDelaying.value = (timer / Delay) * 100;
    }

    private void StatusColor()
    {
        if (Activated)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
