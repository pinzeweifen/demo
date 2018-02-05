using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickUI : MonoBehaviour,IPointerDownHandler {
    public UnityEvent onEvent = new UnityEvent();

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onEvent.Invoke();

        transform.SetAsLastSibling();
    }
}
