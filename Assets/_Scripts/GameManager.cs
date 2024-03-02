using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject miniGamePanel; // Reference to the mini-game panel GameObject
    public MoneyManager moneyManager; // Reference to the MoneyManager script

    private void Awake()
    {
        Instance = this;
    }

    public void StartMiniGame(GameObject npc)
    {
        // Initialize the mini-game when triggered by the NPC
        miniGamePanel.SetActive(true);

        // Reset the Simon Says game to round 1
        npc.GetComponent<SimonSaysGame>().ResetGame();
    }
}
