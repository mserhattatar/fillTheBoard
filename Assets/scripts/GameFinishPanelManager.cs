using UnityEngine;
using UnityEngine.UI;

public class GameFinishPanelManager : MonoBehaviour
{
    public Text FinishTheLevel;
    public Text MainMenuButtonText;
    public Text RetryLevelButtonText;
    private void Start()
    {
        var CText = LanguageManager.instance;

        FinishTheLevel.text = CText.getTranslatedTextOf("FinishTheLevel");
        MainMenuButtonText.text = CText.getTranslatedTextOf("MainMenu");
        RetryLevelButtonText.text = CText.getTranslatedTextOf("RetryLevel");
    }

    public void CloseGameFinishPanel()
    {
        this.gameObject.SetActive(false);
    }
    public void RetryLevelSaveBestScore()
    {
        LevelManager.instance.RetryLevelSaveBestScore();
    }
    public void MainMenu()
    {
        LevelManager.instance.MainMenu();
    }


    //NextGameButton
    public void OpenNextGame(int whichgame)
    {
        LevelManager.instance.OpenNextGame(whichgame);

    }
}
