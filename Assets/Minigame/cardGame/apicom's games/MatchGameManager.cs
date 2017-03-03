using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGameManager : MonoBehaviour {

    public ApicomsDropZone[] zones;
    public bool matchedAll = false;

	void Start () {
        ApicomsDraggable[] aDrags = new ApicomsDraggable[zones.Length];
        for (int i = 0; i < zones.Length; i++)
        {
            aDrags[i] = zones[i].transform.GetChild(0).GetComponent<ApicomsDraggable>();
        }

        for(int i = 0; i < zones.Length; i++)
        {
            while (true)
            {
                int index = Random.Range(0, aDrags.Length);
                if (zones[i].Cell != aDrags[index].cell && !aDrags[index].randomed)
                {
                    aDrags[index].transform.SetParent(zones[i].transform);
                    aDrags[index].randomed = true;
                    break;
                }
            }
        }
    }
	
	void Update () {
        Debug.Log(checkAnswer());
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
