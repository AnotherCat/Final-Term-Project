using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.slot TypeOfItem = Draggable.slot.SKY;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("On pointer Enter");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (TypeOfItem == d.TypeOfItem || TypeOfItem == Draggable.slot.INVENTORY)
            {
                d.placeholderParent = this.transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("On pointer Exit");
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.parentToreturnTo==this.transform)
        {
            if (TypeOfItem == d.TypeOfItem || TypeOfItem == Draggable.slot.INVENTORY)
            {
                d.placeholderParent = d.parentToreturnTo;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "On drop to" + gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if (TypeOfItem == d.TypeOfItem || TypeOfItem == Draggable.slot.INVENTORY)
            {
                d.parentToreturnTo = this.transform;
            }
        }
    }
}
