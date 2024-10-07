using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public event Action<float> horizontalInputPressed;
    public event Action interactionPressed;

    private float horizontalAxis;

    private bool inputEnabled = true;

    public float HorizontalAxis
    {
        get => horizontalAxis;
        set => horizontalAxis = value;
    }

    private void Awake()
    {
        GameStateManager.Instance.stateChanged += StateHandler;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.stateChanged -= StateHandler;
    }

    private void Update()
    {
        if (!inputEnabled) return;

        horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != default)
        {
            horizontalInputPressed?.Invoke(horizontalAxis);
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            interactionPressed?.Invoke();
        }
    }

    private void StateHandler(GameState state)
    {
        switch (state)
        {
            case GameState.Paused:
                inputEnabled = false;
                break;
            case GameState.Playing:
                inputEnabled = true;
                break;
            case GameState.GameOver:
                inputEnabled = false;
                break;
        }
    }
}