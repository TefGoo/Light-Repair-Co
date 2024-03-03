using TMPro;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public int repairCost = 30;
    public MoneyManager moneyManager;
    public GameObject fixedObjectPrefab; // Reference to the fixed object prefab
    public TMP_Text notEnoughMoneyText; // Reference to the TMP text for displaying "Not enough money"
    public AudioClip successSound;

    private bool isFixed = false; // Flag to track if the object is fixed
    private GameObject fixedObject; // Reference to the instantiated fixed object

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        notEnoughMoneyText.gameObject.SetActive(false); // Hide the text initially
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player") && !isFixed)
        {
            FixObject();
        }
    }

    void FixObject()
    {
        if (moneyManager.SpendMoney(repairCost))
        {
            // Play the success sound effect
            AudioSource.PlayClipAtPoint(successSound, transform.position);

            // Instantiate the fixed object prefab at the same position and rotation as the original object
            fixedObject = Instantiate(fixedObjectPrefab, transform.position, transform.rotation);

            // Hide the original object
            gameObject.SetActive(false);

            // Set the object as fixed
            isFixed = true;

            Debug.Log("Object fixed!");

            // Notify the ObjectManager that this object is fixed
            FindObjectOfType<ObjectManager>().ObjectFixed();
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
