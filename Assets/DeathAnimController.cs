using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimController : MonoBehaviour
{
    public Transform[] crosses;

    private GameStateManager gameStateManager;

    private void Awake()
    {
        gameStateManager = GameStateManager.Instance;

        gameStateManager.stateChanged += StateHandler;
    }

    private void OnDestroy()
    {
        if (gameStateManager != null)
        {
            gameStateManager.stateChanged -= StateHandler;
        }
    }

    private void ToggleCrosses(bool toggle)
    {
        for (int i = 0; i < crosses.Length; i++)
        {
            var cross = crosses[i];

            cross.gameObject.SetActive(toggle);
        }
    }

    private void StateHandler(GameState state)
    {
        switch (state)
        {
            case GameState.GameOver:
                ToggleCrosses(true);
                break;
            case GameState.Playing:
                ToggleCrosses(false);
                break;
            case GameState.Paused:
                ToggleCrosses(false);
                break;
        }
    }
}