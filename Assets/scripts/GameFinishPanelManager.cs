using UnityEngine;
using UnityEngine.UI;

public class GameFinishPanelManager : MonoBehaviour
{
    public Text FinishTheLevel;
    public Text StartNewGameButtonText;
    public Text KeepGoingButtonText;
    private void Start()
    {
        var CText = LanguageManager.instance;

        FinishTheLevel.text = CText.getTranslatedTextOf("FinishTheLevel");
        StartNewGameButtonText.text = CText.getTranslatedTextOf("StartNewGameButtonText");
        KeepGoingButtonText.text = CText.getTranslatedTextOf("KeepGoingButtonText");

    }

    public void CloseGameFinishPanel()
    {
        this.gameObject.SetActive(false);
    }
    public void KeepGoing()
    {
        LevelManager.instance.NextScene();
    }
    public void NextGame()
    {
        LevelManager.instance.NextGame();
    }
}
