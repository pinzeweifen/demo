using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public int maxlevel = 6;

    public StartGame startGame;
    public InGame inGame;
    public EndGame endGame;
    public ItemManager itemManager;
    public InputManager inputManager;

    private int level=0;
    private void Awake()
    {
        startGame.ShowInGameEvent += () => {
            inGame.Show();
            inGame.ShowSelect();
        };

        inGame.SelectLevelEvent += level => {
            if(level == -1)
            {
                this.level++;
                level = this.level;
            }
            this.level = level;
            inGame.HideSelect();
            inGame.ShowSlider();
            itemManager.StartLevel(level);

        };

        inGame.ReturnEvent += () =>
        {
            inGame.ShowSelect();
        };

        itemManager.LoseEvent += () => {
            inGame.slider.value--;
            if (inGame.slider.value <= 0)
                endGame.Show();
            ShowNectLevel();
        };
        
        inputManager.NextLevelEvent += () => {
            if (inGame.IsShowNext())
            {
                if (!IsShowEndGame())
                {
                    inGame.HideNextLevel();
                    inGame.NextLevel();
                }
            }
        };

        inputManager.CompleteWordEvent += () => {
            ShowNectLevel();
        };
    }

    private void ShowNectLevel()
    {
        if (itemManager.surplus <= 0)
        {
            if (itemManager.IsEmpty())
            {
                level++;
                if (!IsShowEndGame())
                {
                    inGame.ShowNextLevel();
                }
            }
        }
    }

    private bool IsShowEndGame()
    {
        if (level == maxlevel)
        {
            inGame.Hide();
            endGame.Show();
            return true;
        }
        return false;
    }
}
