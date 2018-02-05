using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHoverUI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    public Image image;
    public Sprite hover;
    private bool isHover = false;
    private Transform imageTr;

    private void Awake()
    {
        imageTr = image.transform;
    }

    private void OnDestroy()
    {
        imageTr = null;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (image != null)
        {
            image.sprite = hover;
            imageTr.gameObject.SetActive(true);
            image.SetNativeSize();
            isHover = true;
            Cursor.visible = false;
        }
    }

    private void Update()
    {
        if (isHover)
        {
            imageTr.position = Input.mousePosition;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        image.sprite = null;
        isHover = false;
        Cursor.visible = true;
        imageTr.gameObject.SetActive(false);
    }
}

