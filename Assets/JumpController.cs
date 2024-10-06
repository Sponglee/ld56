using System;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool isJumping = true;

    public Transform target;
    public float speed = 2f; // Speed of the movement
    public float amplitude = 1f; // Amplitude of the up and down movement

    private InputManager _inputManager;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = target.localPosition;
        _inputManager = InputManager.Instance;

        _inputManager.horizontalInputPressed += UpdateJump;
    }

    private void OnDestroy()
    {
        _inputManager.horizontalInputPressed -= UpdateJump;
    }

    private void UpdateJump(float axisValue)
    {
        isJumping = axisValue != default;

        if (!isJumping) return;

        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        target.localPosition = new Vector3(target.localPosition.x, newY, target.localPosition.z);
    }
}