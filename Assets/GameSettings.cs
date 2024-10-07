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
    public int moneyStartAmount = 250;
    public int rentCost;
    public float rentIncrease;
    public int daysToRent;


    [Header("SPEED")]
    public float speedBoost = 1.5f;
    public float boostDuration = 1f;
    public float moveSpeed;
    public float levelMoveSpeed;
    

    public int GetRentCost()
    {
        return rentCost;
    }

    public int GetRentDays()
    {
        return daysToRent;
    }
}