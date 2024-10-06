using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyItemController : MonoBehaviour
{
    private int moneyAmount;

    private void Awake()
    {
        moneyAmount = GameSettings.Instance.moneyAddAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoneyManager.Instance.AddMoney(moneyAmount);
            Destroy(gameObject);
        }
    }
}