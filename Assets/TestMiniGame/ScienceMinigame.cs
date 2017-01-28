using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScienceMinigame : MonoBehaviour {

    public int[] Answer;
    public int[] result;
    public Sprite[] sprite;
    public Button[] buttons;
    public Button OKButton;

    public ActiveMinigame AM;

    private int index;
    private bool correct = true;

    private void Start()
    {
        index = Answer.Length;

        for (int i = 0; i < buttons.Length; i++)
        {
            int id = i;
            buttons[i].image.sprite = sprite[result[i]];
            buttons[i].onClick.AddListener(delegate { onClickBtn(id); });
        }

        OKButton.onClick.AddListener(delegate { CheckAns(); });
    }

    void onClickBtn(int id)
    {
        result[id]++;
        if (result[id] >= index)
        {
            result[id] = 0;
        }
        buttons[id].image.sprite = sprite[result[id]];
    }

    public void CheckAns()
    {
        for(int i =0;i < Answer.Length; i++)
        {
            if(Answer[i] != result[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            AM.OnCorrect();
        }else
        {
            AM.OnIncorrect();
        }
    }
}
