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

        GameStateManager.Instance.dayPassed += UpdateRent;

        UpdateRent();
    }

    private void OnDestroy()
    {

        if (GameStateManager.Instance != null)
        {
            GameStateManager.Instance.dayPassed -= UpdateRent;
        }
    }

    public void UpdateRent()
    {
        maxRentDays = GameSettings.Instance.GetRentDays();
        currentDay = GameStateManager.Instance.GetCurrentDay();

        daysText.text = $"PAY THE RENT IN: {maxRentDays - currentDay} DAYS";
        
        UpdateText();
    }

    private void UpdateText()
    {
        maxAmount = GameSettings.Instance.GetRentCost();
        rentText.text = $"MONEY TO PAY: ${maxAmount}";
    }
}