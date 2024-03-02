using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public int repairCost = 30;
    public MoneyManager moneyManager;
    public GameObject fixedObjectPrefab; // Reference to the fixed object prefab
    public TMP_Text notEnoughMoneyText; // Reference to the TMP text for displaying "Not enough money"

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        notEnoughMoneyText.gameObject.SetActive(false); // Hide the text initially
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            FixObject();
        }
    }

    void FixObject()
    {
        if (moneyManager.SpendMoney(repairCost))
        {
            // Instantiate the fixed object prefab at the same position and rotation as the original object
            GameObject newObject = Instantiate(fixedObjectPrefab, transform.position, transform.rotation);
            // Destroy the original object
            Destroy(gameObject);
            Debug.Log("Object fixed!");
        }
        else
        {
            // Show "Not enough money" text if player can't afford to fix the object
            notEnoughMoneyText.gameObject.SetActive(true);
            Invoke("HideNotEnoughMoneyText", 2f); // Hide the text after 2 seconds
        }
    }

    void HideNotEnoughMoneyText()
    {
        notEnoughMoneyText.gameObject.SetActive(false); // Hide the text
    }
}
