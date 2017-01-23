using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text S_Text;
    public Text T_Text;
    public Text E_Text;
    public Text M_Text;

    public Text Energy_Text;

    public static int S = 0;
    public static int T = 0;
    public static int E = 0;
    public static int M = 0;
    public static int Energy = 0;

    public void Update()
    {
        S_Text.text = "S : " + S;
        T_Text.text = "T : " + T;
        E_Text.text = "E : " + E;
        M_Text.text = "M : " + M;
        Energy_Text.text = "Energy : " + Energy;
    }
}
