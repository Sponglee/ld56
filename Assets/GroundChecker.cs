using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public event Action groundHit;

    [SerializeField] private bool isChecking = false;

    public bool IsChecking
    {
        get => isChecking;
        set => isChecking = value;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isChecking) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            groundHit?.Invoke();
        }
    }
}