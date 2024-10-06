using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public event Action groundHit;

    private bool isChecking = false;

    public bool IsChecking
    {
        get => isChecking;
        set => isChecking = value;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isChecking) return;

        Debug.Log(other.gameObject.layer == LayerMask.NameToLayer("Ground"));
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            groundHit?.Invoke();
        }
    }
}