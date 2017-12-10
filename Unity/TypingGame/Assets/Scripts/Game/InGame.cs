using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour {

    public Slider slider;

    public GameObject selectLevel;
    public Button[] levelButton;

    public GameObject nextLevel;
    public Button returnButton;
    public Button nextButton;

    public Action<int> SelectLevelEvent;
    public Action ReturnEvent;

    public void Show()
    {
        gameObject.SetActive(true);
        slider.gameObject.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowSelect()
    {
        selectLevel.SetActive(true);
    }

    public void HideSelect()
    {
        selectLevel.SetActive(false);
    }

    public void ShowSlider()
    {
        slider.gameObject.SetActive(true);
    }

    public void HideSlider()
    {
        slider.gameObject.SetActive(false);
    }

    public void ShowNextLevel()
    {
        nextLevel.SetActive(true);
    }

    public void HideNextLevel()
    {
        nextLevel.SetActive(false);
    }

    public void NextLevel()
    {
        SelectLevelEvent(-1);
    }

    public bool IsShowNext()
    {
        return nextLevel.activeSelf;
    }

    private void Awake()
    {
        returnButton.onClick.AddListener(()=> {
            HideNextLevel();
            ReturnEvent();
        });

        nextButton.onClick.AddListener(() => {
            HideNextLevel();
            NextLevel();
        });

        for(int i = 0; i < levelButton.Length; i++)
        {
            var level = i;
            levelButton[i].onClick.AddListener(()=> {
                SelectLevelEvent(level);
            });
        }

        HideNextLevel();
        HideSlider();
        Hide();
    }
    
}
