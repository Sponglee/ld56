using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isJumping = true;

    public Transform target;
    public float speed = 2f; // Speed of the movement
    public float amplitude = 1f; // Amplitude of the up and down movement

    private GameStateManager _gameStateManager;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = target.localPosition;
        _gameStateManager = GameStateManager.Instance;

        _gameStateManager.stateChanged += UpdateJump;
    }

    private void OnDestroy()
    {
        if (_gameStateManager != null)
        {
            _gameStateManager.stateChanged -= UpdateJump;
        }
    }

    private void UpdateJump(GameState state)
    {
        isJumping = state == GameState.Playing;
    }

    private void Update()
    {
        // isJumping = axisValue != default;

        if (!isJumping) return;

        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        target.localPosition = new Vector3(target.localPosition.x, newY, target.localPosition.z);
    }
}