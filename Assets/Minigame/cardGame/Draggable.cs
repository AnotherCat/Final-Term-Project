using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToreturnTo = null;

    public enum slot {INVENTORY, SKY, SKI, SPIRIT}
    public slot TypeOfItem = slot.SKY;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("On");

        parentToreturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End");
        this.transform.SetParent(parentToreturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
