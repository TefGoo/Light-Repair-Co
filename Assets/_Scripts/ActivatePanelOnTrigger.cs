using UnityEngine;

public class ActivatePanelOnTrigger : MonoBehaviour
{
    public GameObject panelToActivate; // Reference to the panel to be activated

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelToActivate.SetActive(true); // Activate the panel
        }
    }
}
