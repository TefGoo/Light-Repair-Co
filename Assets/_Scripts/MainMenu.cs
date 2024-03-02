using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to start the game by loading the game scene
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenu"); // Replace "GameScene" with the name of your game scene
    }

    // Method to load the credits scene
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits"); // Replace "CreditsScene" with the name of your credits scene
    }

    // Method to close the game
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Note: This will only work in a built application, not in the Unity Editor
    }
}
