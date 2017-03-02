using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApicomsDropZone : MonoBehaviour ,IDropHandler,IPointerEnterHandler,IPointerExitHandler{

    public ApicomsDraggable.slot TypeOfItem = ApicomsDraggable.slot.table;
    public bool matched = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("On pointer Enter");
        if (eventData.pointerDrag == null)
            return;

        ApicomsDraggable d = eventData.pointerDrag.GetComponent<ApicomsDraggable>();
        if (d != null)
        {
            if (TypeOfItem == d.TypeOfItem || TypeOfItem == ApicomsDraggable.slot.table)
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

        ApicomsDraggable d = eventData.pointerDrag.GetComponent<ApicomsDraggable>();
        if (d != null && d.parentToreturnTo == this.transform)
        {
            if (TypeOfItem == d.TypeOfItem || TypeOfItem == ApicomsDraggable.slot.table)
            {
                d.placeholderParent = d.parentToreturnTo;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "On drop to" + gameObject.name);
        ApicomsDraggable d = eventData.pointerDrag.GetComponent<ApicomsDraggable>();
        if (d != null)
        {
            if (TypeOfItem == d.TypeOfItem || TypeOfItem == ApicomsDraggable.slot.table)
            {
                d.parentToreturnTo = this.transform;
            }
        }
    }
}
