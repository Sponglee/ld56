using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameSettings : Singleton<GameSettings>
{
    public int obstacleHitMoneyAmount;
    public int moneyAddAmount;
    public int rentCost;


    public int moveSpeed;
    public int daysToRent;
}