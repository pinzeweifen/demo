﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class QCursor : MonoBehaviour {

    public Sprite hover;
    public Sprite down;

    private Image icon;
    private Coroutine start;
    private QEnum.CursorState cursorState;
    
    private void Awake()
    {
        icon = GetComponent<Image>();
        gameObject.AddComponent<CanvasGroup>().blocksRaycasts = false;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        SetState(QEnum.CursorState.Hover);
        Cursor.visible = false;
        gameObject.SetActive(true);
        start = StartCoroutine(CursorPos());
    }

    public void Hide()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
        StopCoroutine(start);
    }
    
    public void SetState(QEnum.CursorState state)
    {
        cursorState = state;
        icon.sprite = state == QEnum.CursorState.Hover ? hover : down;
    }

    IEnumerator CursorPos()
    {
        while (true)
        {
            transform.position = Input.mousePosition;
            yield return null;
        }
    }
}
