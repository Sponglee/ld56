using TMPro;
using UnityEngine;

public class FlyingMoneyItem : MonoBehaviour
{
    [SerializeField] private float moneySpeed = 1;
    [SerializeField] private TMP_Text moneyText;

    [SerializeField] private Vector2 spreadLimits;

    public void Initialize(int amount)
    {
        bool isPositive = amount >= 0;
        var sign = isPositive ? "+" : "-";
        moneyText.text = $"{sign}{Mathf.Abs(amount)}$";

        moneyText.color = isPositive ? Color.green : Color.red;

        transform.position += new Vector3(Random.Range(-spreadLimits.x, spreadLimits.x),
            Random.Range(-spreadLimits.y, spreadLimits.y), 0);
    }

    void Update()
    {
        transform.Translate(Vector3.up * (moneySpeed * Time.deltaTime));
    }
}