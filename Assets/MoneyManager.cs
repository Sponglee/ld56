using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    public event Action<int> moneyAdded;
    public event Action<int> moneyChanged;

    private int money;

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
            PlayerPrefs.SetInt("Money", money);
        }
    }

    private void Awake()
    {
        Money = PlayerPrefs.GetInt("Money", 0);
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        moneyAdded?.Invoke(amount);
    }
}