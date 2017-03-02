using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameManager : MonoBehaviour {

    public ApicomsDropZone[] zones;
    public bool matchedAll = false;

	void Start () {
		
	}
	
	void Update () {
        foreach(ApicomsDropZone a in zones)
        {
            Debug.Log(a.matched);
        }
        //Debug.Log(checkAnswer());
	}

    bool checkAnswer()
    {
        if (zones != null && zones.Length > 0)
        {
            for (int i = 0; i < zones.Length; i++)
            {
                if (!zones[i].matched)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}
