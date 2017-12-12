using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

    private Image icon;

    private void Awake()
    {
        icon = GetComponent<Image>();
        gameObject.SetActive(false);
    }

    public void Show(Sprite sprite)
    {
        icon.sprite = sprite;
        transform.position = Input.mousePosition;
        transform.SetAsLastSibling();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
