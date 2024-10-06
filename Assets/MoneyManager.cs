using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoneyManager : Singleton<MoneyManager>
{
    public GameObject moneyItemPrefab;

    public event Action<int> moneyAdded;
    public event Action<int> moneyChanged;

    private int money;
    private Transform moneyCanvas;

    public int Money
    {
        get { return money; }
        set
        {
            money = value;
            if (money <= 0)
            {
                money = 0;
            }

            moneyChanged?.Invoke(money);
        }
    }

    private void Start()
    {
        moneyCanvas = CanvasManager.Instance.GetCanvas("MoneyCanvas");
        Money = 0;
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        moneyAdded?.Invoke(amount);


        var flyingMoneyItem = Instantiate(moneyItemPrefab, moneyCanvas).GetComponent<FlyingMoneyItem>();

        Destroy(flyingMoneyItem.gameObject, Random.Range(2.8f, 3.1f));
        flyingMoneyItem.Initialize(amount);
    }
}