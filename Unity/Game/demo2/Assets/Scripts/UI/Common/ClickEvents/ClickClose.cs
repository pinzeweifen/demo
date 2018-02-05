using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickClose : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent onEvent = new UnityEvent();

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onEvent.Invoke();
        Destroy(gameObject);
    }

}
