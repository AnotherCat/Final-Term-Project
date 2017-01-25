using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
    public Text text;

    int next = 1;

    public void OnNext()
    {
        next++;
        if (next == 1)
        {
            text.text = "Up";
        }
        else if (next == 2)
        {
            text.text = "Down";
        }
        else if (next == 3)
        {
            text.text = "Right";
        }
        else if (next == 4)
        {
            text.text = "Left";
            next = 0;
        }
    }
}
