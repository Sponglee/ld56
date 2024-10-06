using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MoneyUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private float fillDuration = 0.25f;

    private Tweener _tweener;

    void Awake()
    {
        MoneyManager.Instance.moneyChanged += MoneyHandler;
    }

    private void OnDestroy()
    {
        MoneyManager.Instance.moneyChanged -= MoneyHandler;
    }

    private void MoneyHandler(int amount)
    {
        _tweener?.Kill();
        _tweener = moneyText.DOText(amount.ToString(), fillDuration);
    }
}