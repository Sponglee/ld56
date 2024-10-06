using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : Singleton<GameStateManager>
{
    public event Action<GameState> stateChanged;

    public GameState GameState;

    private void Start()
    {
        ChangeState(GameState.Paused);
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