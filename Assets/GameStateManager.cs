using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : Singleton<GameStateManager>
{
    public event Action<GameState> stateChanged;
    public event Action dayPassed;

    public GameState GameState;

    private int currentDay;

    private void Start()
    {
        ChangeState(GameState.Paused);

        currentDay = 1;
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }

    public void NextDay()
    {
        currentDay++;
        dayPassed?.Invoke();
        CheckDay();
    }

    public void CheckDay()
    {
        if (currentDay >= GameSettings.Instance.daysToRent)
        {
            var currentMoney = MoneyManager.Instance.Money;
            var rentCost = GameSettings.Instance.rentCost;

            if (currentMoney >= rentCost)
            {
                currentDay = 0;
                MoneyManager.Instance.AddMoney(-rentCost);
                //TADA
            }
            else
            {
                // ChangeState(GameState.GameOver);
                MoneyManager.Instance.AddMoney(-currentMoney);
                //NO MONEY
            }
        }
    }

    public void StartClickHandler()
    {
        ChangeState(GameState.Playing);
    }

    public void RestartClickHandler()
    {
        ChangeState(GameState.Paused);
        SceneManager.LoadScene("Main");
    }


    public void ChangeState(GameState targetState)
    {
        GameState = targetState;
        stateChanged?.Invoke(targetState);


        switch (targetState)
        {
            case GameState.Paused:
                break;
            case GameState.Playing:
                CanvasManager.Instance.ToggleCanvas("MenuCanvas", false);
                CanvasManager.Instance.ToggleCanvas("MoneyCanvas", true);
                break;
            case GameState.GameOver:
                CanvasManager.Instance.ToggleCanvas("GameOverCanvas", true);
                CanvasManager.Instance.ToggleCanvas("MoneyCanvas", false);
                break;
        }
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Paused
}