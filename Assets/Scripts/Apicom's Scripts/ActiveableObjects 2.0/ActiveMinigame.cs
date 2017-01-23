using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ActiveMinigame : ActiveableObject20 {

    public int S_need = 0;
    public int T_need = 0;
    public int E_need = 0;
    public int M_need = 0;
    public int Energy_Need = 0;

    public int Gain_S = 0;
    public int Gain_T = 0;
    public int Gain_E = 0;
    public int Gain_M = 0;
    public int Gain_Energy = 0;

    public GameObject MinigameCanvas;
    public GameObject MinigameCamera;

    public UIFloating uiFloating;
    
    private UIFps ui;
    private bool inRangeMinigame = false;

    private void Start()
    {
        MinigameCanvas.SetActive(false);
        MinigameCamera.SetActive(false);
        ui = GameObject.FindGameObjectWithTag("Player").GetComponent<UIFps>();
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            inRangeMinigame = true;
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.tag.Contains("Player"))
        {
            inRangeMinigame = false;
        }
    }

    void DoProcess()
    {
        if (ui != null)
        {
            if (IsLock)
            {
                ui.MidText.text = "";
            }
            else
            {
                if (GameManager.S >= S_need &&
                    GameManager.T >= T_need &&
                    GameManager.E >= E_need &&
                    GameManager.M >= M_need &&
                    GameManager.Energy >= Energy_Need)
                {
                    ui.MidText.text = "Press " + Press.ToString();
                }
                else
                {
                    string whatweneed = "Needs ";
                    if (S_need > GameManager.S)
                    {
                        whatweneed += " [S : " + S_need + "]";
                    }
                    if (T_need > GameManager.T)
                    {
                        whatweneed += " [T : " + T_need + "]";
                    }
                    if (E_need > GameManager.E)
                    {
                        whatweneed += " [E : " + E_need + "]";
                    }
                    if (M_need > GameManager.M)
                    {
                        whatweneed += " [M : " + M_need + "]";
                    }
                    if (Energy_Need > GameManager.Energy)
                    {
                        whatweneed += " [Energy : " + Energy_Need + "]";
                    }
                    ui.MidText.text = whatweneed;
                }

            }

        }
        if (Input.GetKeyDown(Press) &&
            !IsLock &&
            GameManager.S >= S_need &&
            GameManager.T >= T_need &&
            GameManager.E >= E_need &&
            GameManager.M >= M_need &&
            GameManager.Energy >= Energy_Need)
        {

            Interact();
        }
    }

    public override void Interact()
    {
        ui.FreezePlayer();
        ui.ShowCursor();
        MinigameCamera.SetActive(true);
        MinigameCanvas.SetActive(true);
    }

    public void OnCorrect()
    {
        ui.UnfreezePlayer();
        ui.HideCursor();
        MinigameCamera.SetActive(false);
        MinigameCanvas.SetActive(false);

        Activated = true;
        IsLock = true;

        GameManager.S += Gain_S;
        GameManager.T += Gain_T;
        GameManager.E += Gain_E;
        GameManager.M += Gain_M;
        GameManager.Energy += Gain_Energy;

        if (TitleQuest != null && DescriptQuest != null)
        {
            TitleQuest.text = TitleQuestString;
            DescriptQuest.text = DescriptionQuestString;
        }
    }
    public void OnIncorrect()
    {
        ui.UnfreezePlayer();
        ui.HideCursor();
        MinigameCamera.SetActive(false);
        MinigameCanvas.SetActive(false);
    }

    public override void Update()
    {
        base.Update();

        if (uiFloating != null)
        {
            if (Activated || IsLock)
            {
                uiFloating.hide();
            }
            else
            {
                uiFloating.show();
            }
        }
        if (inRangeMinigame)
        {
            DoProcess();
        }
    }
}

