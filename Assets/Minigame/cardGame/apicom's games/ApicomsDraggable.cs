using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApicomsDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum cells {
        t1 = 0,
        t2 = 1,
        t3 = 2,
        t4 = 3,
        t5 = 4,
        t6 = 5,
        t7 = 6,
        t8 = 7,
        t9 = 8,
        t10 = 9,
        t11 = 10,
        t12 = 11,
        t13 = 12,
        t14 = 13,
        t15 = 14,
        t16 = 15
    }
    public cells cell = cells.t1;
    public bool randomed = false;

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
