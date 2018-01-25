using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button start;

    public Action ShowInGameEvent;

    private void Awake()
    {
        start.onClick.AddListener(()=> {
            Hide();
            ShowInGameEvent();
        });
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
