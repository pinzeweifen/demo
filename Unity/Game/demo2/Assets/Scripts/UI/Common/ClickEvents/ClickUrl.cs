using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickUrl : MonoBehaviour,IPointerDownHandler {

    public string url;
    public UnityEvent onEvent = new UnityEvent();

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onEvent.Invoke();

        Application.OpenURL(url);
    }
}
