using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScienceMinigame : MonoBehaviour {

    public float TimeLimits = 10;
    public int[] Answer;
    public int[] result;
    public Sprite[] sprite;
    public Button[] buttons;
    public Slider SliderTimer;

    public ActiveMinigame AM;

    private int index;
    private bool correct = true;
    private float timer = 0;
    private bool timerouted = false;

    private void Start()
    {
        index = Answer.Length;

        for (int i = 0; i < buttons.Length; i++)
        {
            int id = i;
            buttons[i].onClick.AddListener(delegate { onClickBtn(id); });
        }

        restart();
    }
    private void OnEnable()
    {
        restart();
    }
    public void restart()
    {
        timer = TimeLimits;
        timerouted = false;
        for(int i = 0;i < result.Length; i++)
        {
            result[i] = Random.Range(0, Answer.Length);
            while (result[i] == Answer[i])
            {
                result[i] = Random.Range(0, Answer.Length);
            }
            buttons[i].image.sprite = sprite[result[i]];
        }
    }

    void onClickBtn(int id)
    {
        result[id]++;
        if (result[id] >= index)
        {
            result[id] = 0;
        }
        buttons[id].image.sprite = sprite[result[id]];

        CheckAns();
    }

    public void CheckAns()
    {
        correct = true;
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
            timerouted = true;
            AM.OnCorrect();
        }
    }

    private void Update()
    {
        if (timerouted) return;
        timer -= Time.deltaTime;
        SliderTimer.value = (timer / 10) * 100;
        if(timer <= 0)
        {
            timerouted = true;
            AM.OnIncorrect();
        }
    }
}
