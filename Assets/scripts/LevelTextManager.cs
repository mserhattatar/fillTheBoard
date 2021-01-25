using UnityEngine;
using UnityEngine.UI;

public class LevelTextManager : MonoBehaviour
{
    public Text bestScoreNumber;
    public Text bestLevelNumber;
    public Text fakeLevelNumberUI;

    public Text RetryLevel;
    public Text RetryGame;
    public Text StepBack;
    public Text BestScore;
    public Text BestLevel;
    public Text RetryLevel2;
    public Text RetryGame2;
    public Text NextLevel;
    public Text RetryLevel3;
    public Text RetryGame3;   
    public Text YouWin;

    void Start()
    {
        SetText();
        TextLang();

    }
    private void SetText()
    {
        var LevelMatrix = ButtonListManager.instance.Button1.Count;
        fakeLevelNumberUI.text = GameManager.instance.gameData.levelNumberToDisplayDictionary[LevelMatrix].ToString();
        bestScoreNumber.text = GameManager.instance.gameData.bestScoreNumberDictionary[LevelMatrix].ToString();
        bestLevelNumber.text = GameManager.instance.gameData.bestScoreLevelDictionary[LevelMatrix].ToString();
    }
    private void TextLang()
    {
        var CText = LanguageManager.instance;

        RetryLevel.text = CText.getTranslatedTextOf("RetryLevel");
        RetryLevel2.text = CText.getTranslatedTextOf("RetryLevel");
        RetryLevel3.text = CText.getTranslatedTextOf("RetryLevel");
        RetryGame.text = CText.getTranslatedTextOf("RetryGame");
        RetryGame2.text = CText.getTranslatedTextOf("RetryGame");
        RetryGame3.text = CText.getTranslatedTextOf("RetryGame");
        StepBack.text = CText.getTranslatedTextOf("StepBack");
        BestScore.text = CText.getTranslatedTextOf("BestScore");
        BestLevel.text = CText.getTranslatedTextOf("BestLevel");
        NextLevel.text = CText.getTranslatedTextOf("NextLevel");
        YouWin.text = CText.getTranslatedTextOf("YouWin");
    }
}
