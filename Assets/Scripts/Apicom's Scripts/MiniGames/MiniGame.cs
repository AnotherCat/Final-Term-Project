using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour {
    
	void Start () {

	}
	
    public void onCorrect()
    {
        Debug.Log("Correct!!!");
    }

    public void onIncorrect()
    {
        Debug.Log("Incorrect!!!");
    }

    void Update () {
		
	}
}
