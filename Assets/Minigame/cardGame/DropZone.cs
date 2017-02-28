using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Draggable.slot TypeOfItem = Draggable.slot.SKY;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "On drop to"+ gameObject.name);
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null)
        {
            if(TypeOfItem == d.TypeOfItem || TypeOfItem == Draggable.slot.INVENTORY)
            {
                d.parentToreturnTo = this.transform;
            }
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("On pointer Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("On pointer Exit");
    }
}
