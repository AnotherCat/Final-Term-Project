using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour {

    public string[] Ans;
    public Text[] text;
    public Text w;

    bool correct = true;


  //  // Update is called once per frame
  //  void Update () {
		//if(Ans[0] == text[0].text && Ans[1] == text[1].text&& Ans[2] == text[2].text)
  //      {
  //          Debug.Log("Win");
  //      }
  //      else
  //      {
  //          Debug.Log("Try Agian");
  //      }

  //  }

    public void checkCorrect()
    {
        for (int i = 0; i < Ans.Length; i++)
        {
            if (Ans[i] != text[i].text)
            {
                
                correct = false;
                break;
            }
            else
            {
                correct = true;
            }

        }

        Debug.Log(correct);
        if (correct)
        {
            Debug.Log("Winner");
            w.text = "Winner";
        }
        
    }
}
