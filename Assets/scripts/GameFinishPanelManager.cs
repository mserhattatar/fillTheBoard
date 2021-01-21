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
        CText.TranslateText(FinishTheLevel, "Congrats!             You win this game!" , "Tebrikler!             Oyunu Kazandın");
        CText.TranslateText(StartNewGameButtonText, "start new game", "Yeni Oyuna Başla");
        CText.TranslateText(KeepGoingButtonText, "Keep going", "Devam Et");

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
