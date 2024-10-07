using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class DaysUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text daysText;
    [SerializeField] private float fillDuration = 0.25f;

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
        _tweener?.Kill();
        _tweener = daysText.DOText($"DAYS: {daysLeft}", fillDuration);
    }
}