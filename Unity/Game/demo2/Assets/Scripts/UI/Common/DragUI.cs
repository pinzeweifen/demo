using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

    Vector3 offset = Vector3.zero;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - Input.mousePosition;
    }
    
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + offset;
    }
}
