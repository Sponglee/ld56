using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

public class GameSettings : Singleton<GameSettings>
{
    public int distractionMoneyAmount;
    public int obstacleHitMoneyAmount;
    public int moneyAddAmount;
    [FormerlySerializedAs("moneyStatAmount")] public int moneyStartAmount = 250;
    public int rentCost;


    public int moveSpeed;
    public int daysToRent;


    public float inputDelay;

    public int GetRentCost()
    {
        return rentCost;
    }

    public int GetRentDays()
    {
        return daysToRent;
    }
}