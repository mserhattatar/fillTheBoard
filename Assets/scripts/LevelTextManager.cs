using UnityEngine;
using UnityEngine.UI;

public class LevelTextManager : MonoBehaviour
{
    public Text RetryLevel;
    public Text RetryGame;
    public Text StepBack;
    public Text BestScore;
    public Text RetryLevel2;
    public Text RetryGame2;
    public Text NextLevel;
    public Text RetryLevel3;
    public Text RetryGame3;
    
    public Text YouWin;

    void Start()
    {
        var CTex = LanguageManager.instance;
        CTex.TranslateText(RetryLevel, "RETRY LEVEL" , "LEVELI YENILE");
        CTex.TranslateText(RetryLevel2, "RETRY LEVEL", "LEVELI YENILE");
        CTex.TranslateText(RetryLevel3, "RETRY LEVEL", "LEVELI YENILE");
        CTex.TranslateText(RetryGame, "RETRY GAME", "OYUNU YENILE");
        CTex.TranslateText(RetryGame2, "RETRY GAME", "OYUNU YENILE");
        CTex.TranslateText(RetryGame3, "RETRY GAME", "OYUNU YENILE");
        CTex.TranslateText(StepBack, "STEP BACK", "GERİ AL");
        CTex.TranslateText(BestScore, "Best Score", "En iyi Puan");
        CTex.TranslateText(NextLevel, "NEXT LEVEL", "YENİ LEVEL");
        CTex.TranslateText(YouWin, "FINISH THE LEVEL AND WIN THE GAME!", "LEVELI BITIR VE OYUNU KAZAN!");
    }   
}
