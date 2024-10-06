using System;
using UnityEngine;

public class ToggleCoatController : MonoBehaviour
{
    [SerializeField] private Transform[] coat;

    [SerializeField] private GroundChecker groundChecker;

    private bool isCoatOn = false;

    private void Awake()
    {
        groundChecker.groundHit += GroundHit;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleCoat(!isCoatOn);
        }
    }

    private void OnDestroy()
    {
        groundChecker.groundHit -= GroundHit;
    }

    private void GroundHit()
    {
        ToggleCoat(false);
    }

    public void ToggleCoat(bool toggle)
    {
        isCoatOn = toggle;
        for (int i = 0; i < coat.Length; i++)
        {
            var target = coat[i];

            target.gameObject.SetActive(toggle);
        }
    }
}