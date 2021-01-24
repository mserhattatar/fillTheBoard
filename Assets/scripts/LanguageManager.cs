using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace LangNamespace
{   public enum Language
    {
        English,
        Turkish,
        German
    }
}


public class LanguageManager : MonoBehaviour
{
    public Dictionary<string, string> enTextDict = new Dictionary<string, string> {
        { "CreatingBy", "THİS GAME IS CREATED BY   TATAR GAME" }, 
        { "IBackButton", "Back" },
        { "IEvery3rd", "Every 3rd Box" },
        { "IEvery2nd", "Every 2nd Box" },
        { "I5EmptyBoxesText", "5 Empty Boxes" },
        { "I5BlockedBoxesText", "5 Blocked Boxes" },
        
        { "IHowToPlay", "HOW TO PLAY?" },
        { "FinishTheLevel", "Congrats!             You win this game!" },        
        { "RetryLevel", "RETRY LEVEL" },
        { "RetryGame", "RETRY GAME" },
        { "StepBack", "STEP BACK" },
        { "BestScore", "Best Score" },
        { "BestLevel", "Score Level" },
        { "NextLevel", "NEXT LEVEL" },
        { "YouWin", "FINISH THE LEVEL AND WIN THE GAME!" },        
        { "IGameTarget",          "Game         Target Score" },
        { "IGameTargetUnderline", "_____         ____________" },
         { "IDontForgetText2", "*Empty and blocked boxes together." },

        { "IHowToPlayExplanation", "Fill the boxes, reach the target and open the next game!" },
        { "IHowToPlayExplanation2", "Each game has a different target score to teach." },
        { "FollowPattern", "Follow the pattern to fill. You can go to every 3rd box on the straight road and every 2nd box on the cross road." },
        { "Leaveasless", "Leave as less unfilled box as possible because they will be carried over to the next step as blocked boxes." },
        { "RetryGameInfo", "Retry game from starting first level. You will lose the your data except best score for the seelcted game." },
        { "RetryLevelInfo", "Retry level as many time as you wish. Use it especially if you want a better level end or want to change the blocked box positioning." },
        { "IStepBackText", "Go one step back and try your move again. You Have 1 Step Back Right For Every Level and it will be lost if you do not use it." },
        { "IDontForgetText", "Don't Forget! You Can leave only 20 unfilled* boxes  for every level.           Otherwise you must retry the level until you success :)" },
       












    };
    public Dictionary<string, string> trTextDict = new Dictionary<string, string> {
        { "CreatingBy", "BU OYUN TATAR GAME TARAFINDAN OLUSTURULMUSTUR" },
        { "IBackButton", "Geri" },       
        { "IEvery3rd", "Her 3. kutu" },
        { "IEvery2nd", "Her 2. kutu" },
        { "I5EmptyBoxesText", "5 Bos Kutu" },
        { "I5BlockedBoxesText", "5 Kilitlenmis kutu" },       
        { "IHowToPlay", "NASIL OYNANIR?" },
        { "FinishTheLevel", "Tebrikler!             Oyunu Kazandın" },
        { "RetryLevel", "LEVELI YENILE" },
        { "RetryGame", "OYUNU YENILE" },
        { "StepBack", "GERİ AL" },
        { "BestScore", "En iyi Skor" },
        { "BestLevel", "Skor Leveli" },
        { "NextLevel", "SONRAKI LEVEL" },
        { "YouWin", "LEVELI BITIR VE OYUNU KAZAN!" },
        
        { "IGameTarget",          "Oyun          Hedef Skor" },
        { "IGameTargetUnderline", "_____         ___________" },
         { "MainMenu", "Ana Menu" },
         { "IHowToPlayExplanation", "Kutuları doldur, hedefe ulas ve sonraki oyuna geç" },
    };
    public Dictionary<string, string> deTextDict = new Dictionary<string, string> {
        { "CreatingBy", "DIESES SPIEL WURDE VON TATAR GAME ERSTELLT" },
        { "IBackButton", "Zurück" },       
        { "IEvery3rd", "Jede 3. Box" },
        { "IEvery2nd", "Jede 2. Box" },
        { "I5EmptyBoxesText", "5 leere Boxen" },
        { "I5BlockedBoxesText", "5 blockierte Boxen" },
        { "IHowToPlay", "WIE ZU SPIELEN?" },
        { "FinishTheLevel", "Gratulation!             Sie haben das Spiel gewonnen!" },
        { "RetryLevel", "RETRY-LEVEL" },
        { "RetryGame", "RETRY-SPIEL" },
        { "StepBack", "RÜCKSCHRITT" },
        { "BestScore", "Beste Note" },
        { "BestLevel", "Note Level" },
        { "NextLevel", "NÄCHSTES LEVEL" },
        { "YouWin", "BEENDEN SIE DAS LEVEL UND GEWINNEN SIE DAS SPIEL!" },
       
        { "IGameTarget",          "SPIEL        Ziel-Note" },
        { "IGameTargetUnderline", "_____        _________" },
         { "MainMenu", "Hauptmenu" },

          { "IHowToPlayExplanation", "Füllt die Kästchen, erreicht das Ziel und geht zum nächsten Spiel über!" },
    };


    public static LanguageManager instance;

    [HideInInspector]
    public int selectedLang;
    public Dictionary<string, string> selectedDict;
    public Dropdown langDropdown;

    private void Awake()
    { 
        instance = this;

        
    }
    private void Start()
    {
        initLayoutManager();
        
    }
    public void initLayoutManager()
    {
        selectedLang = GameManager.instance.gameData.selectedLang;
        updateSelectedLang(false);
        langDropdown.GetComponent<Dropdown>().value = selectedLang;
    }

    public void updateSelectedLang(bool buttonclick = true)
    {
        int value;       
        if (buttonclick)
        {
            var _LangDropdown = langDropdown.GetComponent<Dropdown>();
            value = _LangDropdown.value;
        }           
        else
            value = selectedLang;

        switch (value)
        {
            case (int)LangNamespace.Language.English:
                selectedLang = (int)LangNamespace.Language.English;
                selectedDict = enTextDict;
                break;
            case (int)LangNamespace.Language.Turkish:
                selectedLang = (int)LangNamespace.Language.Turkish;
                selectedDict = trTextDict;
                break;
            case (int)LangNamespace.Language.German:
                selectedLang = (int)LangNamespace.Language.German;
                selectedDict = deTextDict;
                break;
        }
        SetChangeLang();
    }

    public string getTranslatedTextOf(string name)
    {
        if (selectedDict == null)
            selectedDict = enTextDict;
        return selectedDict[name];
    }

    public void SetChangeLang()
    {
        GameManager.instance.SaveSelectedLanguage();
        FindObjectOfType<MainMenuText>().langChanged = true;
    }
}
