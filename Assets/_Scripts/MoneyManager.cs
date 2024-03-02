using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int startingMoney = 100;
    public int currentMoney;
    public TMP_Text moneyText; // Reference to the TMP text object in the UI

    void Start()
    {
        currentMoney = startingMoney;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        moneyText.text = "Money: " + currentMoney.ToString(); // Update the TMP text to display current money
    }

    public bool CanAfford(int cost)
    {
        return currentMoney >= cost;
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText(); // Update the money text when money is added
    }

    public bool SpendMoney(int amount)
    {
        if (CanAfford(amount))
        {
            currentMoney -= amount;
            UpdateMoneyText(); // Update the money text when money is spent
            return true;
        }
        return false;
    }
}
