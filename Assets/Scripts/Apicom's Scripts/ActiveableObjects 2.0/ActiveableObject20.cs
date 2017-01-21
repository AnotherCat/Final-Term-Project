using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveableObject20 : MonoBehaviour {

    public KeyCode Press;
    public ActiveableObject20[] MustActiveObjects;
    public bool IsLock = false;
    public bool IsToggle = false;
    public bool Activated = false;

    public Text TitleQuest;
    [TextArea]
    public string TitleQuestString;
    public Text DescriptQuest;
    [TextArea]
    public string DescriptionQuestString;

    public virtual void OnTriggerStay(Collider other)
    {
        if (other.tag.Contains("Player")) // player in range
        {
            UIFps ui = other.GetComponent<UIFps>();
            if(ui != null)
            {
                if (IsLock)
                {
                    ui.MidText.text = "";
                }else
                {
                    ui.MidText.text = "Press " + Press.ToString();
                }
                
            }
            if (Input.GetKeyDown(Press) && !IsLock)
            {
                Interact();
            }
        }
    }
    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            UIFps ui = other.GetComponent<UIFps>();
            if (ui != null)
            {
                ui.MidText.text = "";
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interace" + gameObject);
    }

    public virtual void Update()
    {
        if (!IsToggle && Activated) return;
        if (MustActiveObjects.Length > 0 && MustActiveObjects != null)
        {
            IsLock = false;
            for (int i = 0; i < MustActiveObjects.Length; i++)
            {
                if (!MustActiveObjects[i].Activated)
                {
                    IsLock = true;
                    break;
                }
            }
        }
    }
}
