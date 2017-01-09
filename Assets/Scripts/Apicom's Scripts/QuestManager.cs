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
    public Objective[] quest_objectives;
}

[Serializable]
public class Objective
{
    public ActiveableObject MustActiveObject;
    public GameObject[] Navigators;
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

            // hide all navigator first
            for(int i = 0;i < quests.Count; i++)
            {
                for(int j = 0;j < quests[i].quest_objectives.Length; j++)
                {
                    hideNavigator(i, j);
                }
            }

            showNavigator(current_index, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (quests == null || quests_size == 0) return;

        ConditionQuest();

        if (previous_index == current_index || current_index >= quests_size || current_index < 0) return;

        for(int i = 0;i < quests[current_index].quest_objectives.Length; i++)
        {
            for(int j = 0; j < quests[current_index].quest_objectives[i].Navigators.Length; j++)
            {

            }
        }

        string quest_name = quests[current_index].quest_title;
        string quest_desc = quests[current_index].quest_description;

        NameText.text = quest_name;
        DescriptionText.text = quest_desc;

        previous_index = current_index;
	}

    void ConditionQuest()
    {
        if (current_index > quests.Count - 1) return;

        int objective_length = quests[current_index].quest_objectives.Length;
        bool foo = true;

        if(objective_length == 0)
        {
            foo = false;
            return;
        }

        for(int i = 0;i < objective_length; i++)
        {
            //if (!quests[current_index].quest_objectives[i].MustActiveObject.Activated)
            //{
            //    foo = false;
            //    break;
            //}
            if (quests[current_index].quest_objectives[i].MustActiveObject.Activated)
            {
                for(int j = 0; j < quests[current_index].quest_objectives[i].Navigators.Length; j++)
                {
                    hideNavigator(current_index, i);
                }
            }else
            {
                foo = false;
            }
        }
        if (foo)
        {
            // hide all navigator before change objective
            for(int i = 0; i < quests[current_index].quest_objectives.Length; i++)
            {
                hideNavigator(current_index, i);
            }
            current_index++;

            // show
            for (int i = 0; i < quests[current_index].quest_objectives.Length; i++)
            {
                showNavigator(current_index, i);
            }
        }
    }

    void hideNavigator(int quest_index,int objective_index)
    {
        for(int i = 0;i < quests[quest_index].quest_objectives[objective_index].Navigators.Length; i++)
        {
            quests[quest_index].quest_objectives[objective_index].Navigators[i].SetActive(false);
        }
    }

    void showNavigator(int quest_index, int objective_index)
    {
        for (int i = 0; i < quests[quest_index].quest_objectives[objective_index].Navigators.Length; i++)
        {
            quests[quest_index].quest_objectives[objective_index].Navigators[i].SetActive(true);
        }
    }
}
