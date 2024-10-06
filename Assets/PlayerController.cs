using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GroundChecker groundChecker;


    public void ToggleGroundChecker(bool toggle)
    {
        groundChecker.IsChecking = toggle;
    }
}