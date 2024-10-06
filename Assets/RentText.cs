using TMPro;
using UnityEngine;

public class RentText : MonoBehaviour
{
    [SerializeField] private TMP_Text rentText;
    [SerializeField] private TMP_Text daysText;

    private int maxAmount;
    private int maxRentDays;
    private int currentDay;

    private void Awake()
    {
        MoneyManager.Instance.moneyChanged += UpdateText;
        GameStateManager.Instance.dayPassed += UpdateRent;

        UpdateRent();
    }

    private void OnDestroy()
    {
        MoneyManager.Instance.moneyChanged -= UpdateText;
        GameStateManager.Instance.dayPassed -= UpdateRent;
    }

    public void UpdateRent()
    {
        maxRentDays = GameSettings.Instance.GetRentDays();
        currentDay = GameStateManager.Instance.GetCurrentDay();

        daysText.text = $"RENT DUE IN: {maxRentDays - currentDay} DAYS";
    }

    private void UpdateText(int amount)
    {
        maxAmount = GameSettings.Instance.GetRentCost();
        rentText.text = $"MONEY TO PAY: ${amount} / ${maxAmount}";
    }
}