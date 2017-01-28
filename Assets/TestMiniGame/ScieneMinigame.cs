using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScieneMinigame : MonoBehaviour {

    public int[] Answer;
    public int[] result;
    public Sprite[] sprite;
    public Button[] buttons;
    public int index;

    private void Start()
    {
        index = Answer.Length;
        
        for(int i = 0;i < buttons.Length;i++)
        {
            int id = i;
            buttons[i].image.sprite = sprite[result[i]];
            buttons[i].onClick.AddListener(delegate { onClickBtn(id); });
        }
    }

    void onClickBtn(int id)
    {
        result[id]++;
        if(result[id] >= index)
        {
            result[id] = 0;
        }
        buttons[id].image.sprite = sprite[result[id]];
    }

}
