using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class EventListener : EventTrigger
{
    public Action<PointerEventData> onClick;
    public Action<PointerEventData> onDoubleClick;
    public Action<PointerEventData> onMouseUp;
    public Action<PointerEventData> onMouseDown;
    public Action<PointerEventData> onEnter;
    public Action<PointerEventData> onExit;
    public Action<PointerEventData> onInitializePotentialDrag;
    public Action<PointerEventData> onBeginDrag;
    public Action<PointerEventData> onDrop;
    public Action<PointerEventData> onDrag;
    public Action<PointerEventData>onEndDrag;
    public Action<PointerEventData> onScroll;
    public Action<BaseEventData> onSelect;
    public Action<BaseEventData> onUpdateSelected;
    public Action<BaseEventData> onSubmit;
    public Action<BaseEventData> onCancel;
    public Action<AxisEventData> onMove;
    public Action<BaseEventData> onDeselect;

    static public EventListener Get(GameObject go)
    {
        EventListener listener = go.GetComponent<EventListener>();
        if (listener == null) listener = go.AddComponent<EventListener>();
        return listener;
    }

    public static void SetFocus(GameObject go)
    {
        EventSystem.current.SetSelectedGameObject(go);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        SetFocus(gameObject);
        if(eventData.clickCount == 1)
        {
            if (onClick != null) onClick(eventData);
        }
        else if(eventData.clickCount == 2)
        {
            if (onDoubleClick != null) onDoubleClick(eventData);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onMouseUp != null) onMouseUp(eventData);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        SetFocus(gameObject);
        if (onMouseDown != null) onMouseDown(eventData);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null)
            onEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null)
            onExit(eventData);
    }

    public override void OnInitializePotentialDrag(PointerEventData eventData)
    {
        SetFocus(gameObject);
        if (onInitializePotentialDrag != null)
            onInitializePotentialDrag(eventData);
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (onBeginDrag != null)
            onBeginDrag(eventData);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (onDrag != null)
            onDrag(eventData);
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (onDrop != null)
            onDrop(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        SetFocus(gameObject);
        if (onEndDrag != null)
            onEndDrag(eventData);
    }

    public override void OnScroll(PointerEventData eventData)
    {
        if (onScroll != null)
            onScroll(eventData);
    }

    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null)
            onSelect(eventData);
    }

    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelected != null)
            onUpdateSelected(eventData);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        if (onSubmit != null)
            onSubmit(eventData);
    }

    public override void OnCancel(BaseEventData eventData)
    {
        if (onCancel != null)
            onCancel(eventData);
    }

    public override void OnMove(AxisEventData eventData)
    {
        if (onMove != null)
            onMove(eventData);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        if (onDeselect != null)
            onDeselect(eventData);
    }
}