using UnityEngine;

public class EscPanelToggle : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject
    private bool panelActive = false; // Flag to track if the panel is currently active

    void Update()
    {
        // Check if the player presses the "Escape" key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the panel's visibility
            TogglePanel();
        }
    }

    void TogglePanel()
    {
        if (panel != null)
        {
            panelActive = !panelActive; // Toggle the panel's active state

            // Set the panel's active state based on the flag
            panel.SetActive(panelActive);
        }
    }
}
