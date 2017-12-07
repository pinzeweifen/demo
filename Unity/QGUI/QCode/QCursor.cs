﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class QCursor : MonoBehaviour {

    public Sprite hover;
    public Sprite down;

    private Image icon;
    private QEnum.CursorState cursorState;

    private void Awake()
    {
        icon = GetComponent<Image>();
        gameObject.AddComponent<CanvasGroup>().blocksRaycasts = false;
        gameObject.SetActive(false);
    }

    public void show()
    {
        setState(QEnum.CursorState.Hover);
        Cursor.visible = false;
        gameObject.SetActive(true);
        StartCoroutine(CursorPos());
    }

    public void hide()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
    
    public void setState(QEnum.CursorState state)
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
