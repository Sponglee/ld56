using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GroundChecker groundChecker;

    private int obstacleHitAmount;

    private void Awake()
    {
        obstacleHitAmount = GameSettings.Instance.obstacleHitMoneyAmount;
        groundChecker.groundHit += GameOverChecker;
    }

    private void OnDestroy()
    {
        groundChecker.groundHit -= GameOverChecker;
    }

    public void GameOverChecker()
    {
        GameStateManager.Instance.ChangeState(GameState.GameOver);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            MoneyManager.Instance.AddMoney(-obstacleHitAmount);
        }
    }
}