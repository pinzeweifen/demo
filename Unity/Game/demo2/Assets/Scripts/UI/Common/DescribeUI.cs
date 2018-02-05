using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DescribeUI : MonoBehaviour,IPointerEnterHandler {

    public string describe;
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }
    public StringEvent enterEvent = new StringEvent();

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        enterEvent.Invoke(describe);
    }
}
