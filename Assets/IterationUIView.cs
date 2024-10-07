using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class IterationUIView : MonoBehaviour
{
    [FormerlySerializedAs("daysText")] [SerializeField] private TMP_Text iterationText;

    private Tweener _tweener;

    void Awake()
    {
        GameStateManager.Instance.dayPassed += DaysHandler;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.dayPassed -= DaysHandler;
    }

    private void DaysHandler()
    {
        var daysToRent = GameSettings.Instance.daysToRent;
        var currentDay = GameStateManager.Instance.GetCurrentDay();
        var daysLeft = daysToRent - currentDay;
        iterationText.text = $"WORKING EXPERIENCE {daysLeft} DAYS";
    }
}