using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickShow : MonoBehaviour,IPointerDownHandler {

    public Transform showObj;
    public UnityEvent onEvent = new UnityEvent();

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onEvent.Invoke();
        showObj.gameObject.SetActive(true);
    }
}
