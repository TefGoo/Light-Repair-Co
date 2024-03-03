using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class SimonSaysGame : MonoBehaviour
{
    public TMP_Text roundText;
    public Button[] simonButtons;
    public float sequenceDelay = 1f;
    public float buttonHighlightDuration = 0.5f;
    public int initialSequenceLength = 2;
    public int sequenceIncrement = 1;
    public int rewardAmount = 10;
    public GameObject simonSaysPanel; // Reference to the UI panel GameObject
    public TMP_Text errorMessageText; // Reference to the TMP text for error message
    public MoneyManager moneyManager; // Reference to the MoneyManager script
    public GameObject[] objectsToDestroy; // Array of GameObjects to destroy when closing the panel

    private List<int> sequence = new List<int>();
    private int currentRound = 1;
    private int playerIndex = 0;
    private bool playerTurn = false;

    void Start()
    {
        currentRound = 1; // Set current round to 1 when the game starts
        Time.timeScale = 1; // Ensure game time is not paused initially
        StartCoroutine(PlaySequence());
    }

    public IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < currentRound + initialSequenceLength - 1; i++)
        {
            int randomIndex = Random.Range(0, simonButtons.Length);
            sequence.Add(randomIndex);
            yield return new WaitForSeconds(sequenceDelay);
        }

        foreach (int buttonIndex in sequence)
        {
            HighlightButton(buttonIndex);
            yield return new WaitForSeconds(buttonHighlightDuration);
            ClearButtonHighlight(buttonIndex);
            yield return new WaitForSeconds(0.1f);
        }

        playerTurn = true;
    }

    void HighlightButton(int index)
    {
        simonButtons[index].image.color = Color.gray;
    }

    void ClearButtonHighlight(int index)
    {
        simonButtons[index].image.color = Color.white;
    }

    public void OnButtonClick(int index)
    {
        if (playerTurn)
        {
            if (index == sequence[playerIndex])
            {
                HighlightButton(index);
                playerIndex++;

                if (playerIndex >= sequence.Count)
                {
                    StartCoroutine(NextRound());
                }
            }
            else
            {
                StartCoroutine(GameOver());
            }

            ClearAllButtonHighlights();
        }
    }

    IEnumerator NextRound()
    {
        yield return new WaitForSeconds(1f);
        playerIndex = 0;
        sequence.Clear();
        currentRound++;
        roundText.text = "Round: " + currentRound;
        playerTurn = false;

        if (currentRound > 3)
        {
            RewardPlayer();
            ClosePanelAndDestroy();
            Time.timeScale = 1; // Resume game time
        }
        else
        {
            StartCoroutine(PlaySequence());
        }
    }

    void RewardPlayer()
    {
        moneyManager.AddMoney(rewardAmount); // Add $10 to the player's money
    }

    IEnumerator GameOver()
    {
        simonSaysPanel.SetActive(false); // Deactivate the UI panel
        errorMessageText.gameObject.SetActive(true); // Show error message
        ClosePanelAndDestroy();
        Time.timeScale = 1; // Ensure game time is resumed
        errorMessageText.text = "";
        yield return new WaitForSeconds(3f); // Wait for 3 seconds before hiding error message
        errorMessageText.gameObject.SetActive(false); // Hide error message
        errorMessageText.gameObject.SetActive(false); // Hide error message
    }

    void ClearAllButtonHighlights()
    {
        foreach (Button button in simonButtons)
        {
            button.image.color = Color.white;
        }
    }

    // Method to close the panel and destroy specified GameObjects
    void ClosePanelAndDestroy()
    {
        simonSaysPanel.SetActive(false); // Close the panel

        // Destroy the specified GameObjects
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }

    // Method to reset the game to round 1
    public void ResetGame()
    {
        currentRound = 1;
        roundText.text = "Round: " + currentRound;
        sequence.Clear();
        StartCoroutine(PlaySequence());
    }
}
