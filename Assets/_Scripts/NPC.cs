using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject npcGameObject; // Reference to the NPC game object
    public GameObject miniGamePanel; // Reference to the minigame panel GameObject
    public SimonSaysGame simonSaysGame; // Reference to the SimonSaysGame script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activate the minigame panel
            if (miniGamePanel != null)
            {
                miniGamePanel.SetActive(true);
            }
            else
            {
                Debug.LogError("Minigame panel is not assigned in NPC script.");
            }

            // Start a coroutine to delay the movement of the NPC game object
            StartCoroutine(DelayedMoveNPC());
        }
    }

    IEnumerator DelayedMoveNPC()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        // Move the NPC game object in the X-axis by -300 units
        if (npcGameObject != null)
        {
            Vector3 newPosition = npcGameObject.transform.position + new Vector3(-300f, 0f, 0f);
            npcGameObject.transform.position = newPosition;
        }
        else
        {
            Debug.LogError("NPC game object is not assigned in NPC script.");
        }
    }

    // Method to be called when the minigame is completed
    public void OnMiniGameComplete(bool success)
    {
        if (success)
        {
            // Destroy the NPC game object if the player succeeds
            Destroy(npcGameObject);
        }
        else
        {
            // Destroy the NPC game object if the player fails
            Destroy(gameObject);
        }
    }
}
