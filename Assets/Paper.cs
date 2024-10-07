using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private Transform endPoint;
    public void MoveTo(PaperReciever paperReciever)
    {
        endPoint = paperReciever.recievePoint;
        transform.SetParent(null);
        transform.DOMove(endPoint.position, 1f).SetEase(Ease.OutCirc).OnComplete(() =>
        {
            MoneyManager.Instance.AddMoney(GameSettings.Instance.moneyAddAmount);
            Destroy(gameObject);
        });
    }
}
