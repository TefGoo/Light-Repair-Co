using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objectsToFix; // Array of objects to fix
    public GameObject completionPanel; // Reference to the completion panel
    public TMP_Text completionText; // Text to display on the completion panel
    public AudioClip completionSound; // Sound to play when all objects are fixed

    private int fixedObjectsCount = 0; // Counter for the number of fixed objects

    void Start()
    {
        // Initialize the completion panel
        if (completionPanel != null)
        {
            completionPanel.SetActive(false); // Hide the completion panel initially
        }
    }

    // Method to call when an object is fixed
    public void ObjectFixed()
    {
        // Increment the counter
        fixedObjectsCount++;

        // Check if all objects have been fixed
        if (fixedObjectsCount >= objectsToFix.Length)
        {
            // Show the completion panel
            ShowCompletionPanel();
        }
    }

    // Method to show the completion panel
    void ShowCompletionPanel()
    {
        // Play the completion sound effect
        AudioSource.PlayClipAtPoint(completionSound, transform.position);

        // Set the completion text
        if (completionText != null)
        {
            completionText.text = "All objects fixed!";
        }

        // Show the completion panel
        if (completionPanel != null)
        {
            completionPanel.SetActive(true);
        }
    }
}
