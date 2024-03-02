using UnityEngine;
using UnityEngine.UI;

public class SimonButton : MonoBehaviour
{
    public int buttonIndex;
    private Button button;
    private SimonSaysGame simonGame;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        simonGame = FindObjectOfType<SimonSaysGame>();
    }

    void OnClick()
    {
        simonGame.OnButtonClick(buttonIndex);
    }
}
