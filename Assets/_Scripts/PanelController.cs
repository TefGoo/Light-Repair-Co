using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(true); // Show the panel when the scene loads
        }
    }

    public void ClosePanelAndStartScene()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Close the panel
        }
    }
}
