using System;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    public event Action<GameState> stateChanged;

    public GameState GameState;

    private void Awake()
    {
        ChangeState(GameState.Paused);
    }

    public void StartClickHandler()
    {
        ChangeState(GameState.Playing);
    }


    public void ChangeState(GameState targetState)
    {
        GameState = targetState;
        stateChanged?.Invoke(targetState);
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Paused
}