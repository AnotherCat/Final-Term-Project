using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApicomsDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum cells { t1, t2, t3, t4 }
    public cells cell = cells.t1;

    public Transform parentToreturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    public enum slot { table }
    public slot TypeOfItem = slot.table;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToreturnTo = this.transform.parent;
        placeholderParent = parentToreturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        this.transform.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        this.transform.SetParent(parentToreturnTo);
        
        //this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        //Destroy(placeholder);
    }
}
