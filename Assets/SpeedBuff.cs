 using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public bool IsBuff = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelController.Instance.BuffSpeed(IsBuff);
        }
    }
}
