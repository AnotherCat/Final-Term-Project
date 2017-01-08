using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Quest
{
    public string quest_title;
    public string quest_description;
    public ActiveableObject[] MustActiveObjects;
}

public class QuestManager : MonoBehaviour {

    // public variable
    public Text NameText;
    public Text DescriptionText;
    public List<Quest> quests;

    // private variable
    int quests_size;
    int current_index;
    int previous_index;

	// Use this for initialization
	void Start () {
        if(quests != null)
        {
            quests_size = quests.Count;
            current_index = 0;
            previous_index = 0;

            NameText.text = quests[current_index].quest_title;
            DescriptionText.text = quests[current_index].quest_description;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (quests == null || quests_size == 0) return;

        ConditionQuest();

        if (previous_index == current_index || current_index >= quests_size || current_index < 0) return;

        string quest_name = quests[current_index].quest_title;
        string quest_desc = quests[current_index].quest_description;

        NameText.text = quest_name;
        DescriptionText.text = quest_desc;

        previous_index = current_index;
	}

    void ConditionQuest()
    {
        if (current_index > quests.Count - 1) return;

        int mustActiveObjects = quests[current_index].MustActiveObjects.Length;
        bool foo = true;

        if(mustActiveObjects == 0)
        {
            foo = false;
            return;
        }

        for(int i = 0;i < mustActiveObjects; i++)
        {
            if (!quests[current_index].MustActiveObjects[i].Activated)
            {
                foo = false;
                break;
            }
        }
        if (foo)
        {
            current_index++;
        }
    }
}
