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
        { "IMainMenuText", "Main Menu" },
        { "IRetryGameText", "Try Again From Sarting Level 1" },
        { "IRetryLevelText", "Try Again The Level" },
        { "IStepBackText", "You Have 1 Step Back Right For Every Level" },
        { "IEvery3rd", "Every 3rd Box" },
        { "IEvery2nd", "Every 2nd Box" },
        { "I5EmptyBoxesText", "5 Empty Boxes" },
        { "I5BlockedBoxesText", "5 Blocked Boxes" },
        { "IDontForgetText", "Don't Forget! You Can leave only 20 unfilled* boxes  for every level." },
        { "IDontForgetText2", "*Empty and blocked boxes together." },
        { "IHowToPlay", "HOW TO PLAY" },
        { "FinishTheLevel", "Congrats!             You win this game!" },
        { "StartNewGameButtonText", "start new game" },
        { "KeepGoingButtonText", "Keep going" }, 
        { "RetryLevel", "RETRY LEVEL" },
        { "RetryGame", "RETRY GAME" },
        { "StepBack", "STEP BACK" },
        { "BestScore", "Best Score" },
        { "BestLevel", "Score Level" },
        { "NextLevel", "NEXT LEVEL" },
        { "YouWin", "FINISH THE LEVEL AND WIN THE GAME!" },
    };

    public Dictionary<string, string> trTextDict = new Dictionary<string, string> {
        { "CreatingBy", "BU OYUN TATAR GAME TARAFINDAN OLUŞTURULMUSTUR" },
        { "IBackButton", "Geri" },
        { "IMainMenuText", "Ana Menu" },
        { "IRetryGameText", "Oyunu 1.Level'dan baslayarak tekrar dene" },
        { "IRetryLevelText", "Bu Levelı tekrarla" },
        { "IStepBackText", "Her levelda bir yazılmıs kutuyu geri alma hakkın var" },
        { "IEvery3rd", "Her 3. kutu" },
        { "IEvery2nd", "Her 2. kutu" },
        { "I5EmptyBoxesText", "5 Bos Kutu" },
        { "I5BlockedBoxesText", "5 Kilitlenmis kutu" },
        { "IDontForgetText", "Unutma! Her levelda sadece 20 kutu boş bırakabilirsin." },
        { "IDontForgetText2", "*Bos ve kilitlenmiş kutular dahil." },
        { "IHowToPlay", "NASIL OYNANIR" },
        { "FinishTheLevel", "Tebrikler!             Oyunu Kazandın" },
        { "StartNewGameButtonText", "Yeni Oyuna Başla" },
        { "KeepGoingButtonText", "Devam Et" },
        { "RetryLevel", "LEVELI YENILE" },
        { "RetryGame", "OYUNU YENILE" },
        { "StepBack", "GERİ AL" },
        { "BestScore", "En iyi Skor" },
        { "BestLevel", "Skor Leveli" },
        { "NextLevel", "SONRAKI LEVEL" },
        { "YouWin", "LEVELI BITIR VE OYUNU KAZAN!" },
    };
    public Dictionary<string, string> deTextDict = new Dictionary<string, string> {
        { "CreatingBy", "DIESES SPIEL WURDE VON TATAR GAME ERSTELLT" },
        { "IBackButton", "Zurück" },
        { "IMainMenuText", "Hauptmenu" },
        { "IRetryGameText", "Versuchen Sie es noch einmal von Level 1 aus" },
        { "IRetryLevelText", "Versuchen Sie das Level erneut" },
        { "IStepBackText", "Sie haben 1 Schritt zurück rechts für jedes Level"},
        { "IEvery3rd", "Jede 3. Box" },
        { "IEvery2nd", "Jede 2. Box" },
        { "I5EmptyBoxesText", "5 leere Boxen" },
        { "I5BlockedBoxesText", "5 blockierte Boxen" },
        { "IDontForgetText", "Vergessen Sie nicht! Sie können nur 20 ungefüllte* Boxen je Level stehen lassen." },
        { "IDontForgetText2", "*Leere und blockierte Boxen zusammen." },
        { "IHowToPlay", "WIE ZU SPIELEN?" },
        { "FinishTheLevel", "Gratulation!             Sie haben das Spiel gewonnen!" },
        { "StartNewGameButtonText", "Neues Spiel starten" },
        { "KeepGoingButtonText", "Weitermachen" },
        { "RetryLevel", "RETRY-LEVEL" },
        { "RetryGame", "RETRY-SPIEL" },
        { "StepBack", "RÜCKSCHRITT" },
        { "BestScore", "Beste Note" },
        { "BestLevel", "Note Level" },
        { "NextLevel", "NÄCHSTES LEVEL" },
        { "YouWin", "BEENDEN SIE DAS LEVEL UND GEWINNEN SIE DAS SPIEL!" },
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
