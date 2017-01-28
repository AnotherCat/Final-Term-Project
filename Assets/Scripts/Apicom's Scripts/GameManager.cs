using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    public Text S_Text;
    public Text T_Text;
    public Text E_Text;
    public Text M_Text;
    public Text Energy_Text;

    public int S = 0;
    public int T = 0;
    public int E = 0;
    public int M = 0;
    public int Energy = 0;

    public GameObject[] ScienceExtra;
    public GameObject[] TechnologyExtra;
    public GameObject[] EngineeringExtra;
    public GameObject[] MathematicExtra;
    public GameObject[] EnergyExtra;

    private void Awake()
    {
        if(GM == null)
        {
            GM = GetComponent<GameManager>();
        }
    }

    private void Start()
    {
        RefreshUI();
    }

    public void Update()
    {
        
    }

    public void RefreshUI()
    {
        updateIndicator(ScienceExtra, S);
        updateIndicator(TechnologyExtra, T);
        updateIndicator(EngineeringExtra, E);
        updateIndicator(MathematicExtra, M);
        updateIndicator(EnergyExtra, Energy);

        S_Text.text = "S : " + S;
        T_Text.text = "T : " + T;
        E_Text.text = "E : " + E;
        M_Text.text = "M : " + M;
        Energy_Text.text = "Energy : " + Energy;
    }

    void updateIndicator(GameObject[] Extra,int STEM)
    {
        for (int i = 0; i < Extra.Length; i++)
        {
            if (i < (STEM))
            {
                Extra[i].SetActive(true);
            }
            else
            {
                Extra[i].SetActive(false);
            }
        }
    }
}
