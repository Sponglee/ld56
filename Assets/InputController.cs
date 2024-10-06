using System;
using UnityEngine;

public class InputController : Singleton<InputController>
{
    public event Action<float> horizontalInputPressed;

    public float HorizontalAxis
    {
        get => horizontalAxis;
        set => horizontalAxis = value;
    }

    private float horizontalAxis;

    private void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != default)
        {
            horizontalInputPressed?.Invoke(horizontalAxis);
        }
    }
}