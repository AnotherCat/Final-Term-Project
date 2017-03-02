using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApicomsDropZone : MonoBehaviour ,IDropHandler,IPointerEnterHandler,IPointerExitHandler{

    public ApicomsDraggable.cells Cell = ApicomsDraggable.cells.t1;

    public ApicomsDraggable.slot TypeOfItem = ApicomsDraggable.slot.table;
    public bool matched = false;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerDrag.name + "On drop to" + gameObject.name);
        ApicomsDraggable d = eventData.pointerDrag.GetComponent<ApicomsDraggable>();
        if (d != null && gameObject.transform.childCount > 0 )
        {
            gameObject.transform.GetChild(0).SetParent(d.parentToreturnTo);
            if (TypeOfItem == d.TypeOfItem || TypeOfItem == ApicomsDraggable.slot.table)
            {
                d.parentToreturnTo = this.transform;
                checkforAnswer(d.cell, Cell);
            }          
        }
    }

    void checkforAnswer(ApicomsDraggable.cells c1,ApicomsDraggable.cells c2)
    {
        if(c1 == c2)
        {
            matched = true;
        }else
        {
            matched = false;
        }
    }
}
