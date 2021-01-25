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

    //button on click func
    public void CloseGameFinishPanel()
    {
        this.gameObject.SetActive(false);
    }
    public void RetryLevelSaveBestScore()
    {
        GameManager.instance.SaveBestScore();
        LevelManager.instance.RetryScene();
    }
    public void MainMenu()
    {
        LevelManager.instance.MainMenu();
    }
    public void OpenNextGame(int whichgame)
    {
        LevelManager.instance.OpenNextGame(whichgame);

    }
}
