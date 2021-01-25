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
        { "CreatingBy", "THİS GAME IS CREATED BY FunTactic GAME" }, 
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
        

        { "IHowToPlayExplanation", "Fill the boxes, reach the target and open the next game!" },
        { "IHowToPlayExplanation2", "Each game has a different target score to reach." },
        { "FollowPattern", "Follow the pattern to fill. You can go to every 3rd box on the straight step and every 2nd box on the cross step." },
        { "Leaveasless", "Leave as few unfilled box as possible because they will be transferred to the next level as blocked boxes." },
        { "RetryGameInfo", "Retry the game from starting first level. You will lose the your data except best score for the seelcted game." },
        { "RetryLevelInfo", "Retry the level as many times as you want. Use this button especially if you want a better level end or want to change the position of the blocked boxes at the level start." },
        { "IStepBackText", "Take a step back and try your move again. You Have 1 Step Back Right For Every Level and it is lost if you don't use it." },
        { "IDontForgetText", "Don't Forget! You Can leave maximum 20 unfilled* boxes  in each level.           Otherwise you need to retry the level until you fill enough boxes :)" },
        { "IDontForgetText2", "*Empty and blocked boxes together." },
        { "NextButtonText", "Next" },
        { "BackButtonText", "Back" },
    };
    public Dictionary<string, string> trTextDict = new Dictionary<string, string> {
        { "CreatingBy", "BU OYUN     FunTactic GAME TARAFINDAN OLUSTURULMUSTUR" },
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
        { "IHowToPlayExplanation2", "Her oyunun farklı bir hedef skoru var." },
        { "FollowPattern", "Kutulari doldurmak icin deseni izle. Düz adımda her 3. Kutuya, çapraz adamlarda her 2. Kutuya gidebilirsin." },
        { "Leaveasless", "Olabildigince az bos kutu birak cunku doldurulmamış kutular sonraki leverde bloklanmis olarak aktarılacak." },
        { "RetryGameInfo", "Ilk level dan baslayarak oyunu yeniden dene. En iyi skor hariç bu oyuna ait verilerini kaybedeceksin." },
        { "RetryLevelInfo", "Leveli istedigin kadar yeniden dene. Bu butonu ozellikle daha iyi bir level sonu basarisi istiyorsan yada level basında bloklanmis kutuların pozisyonunu değiştirmek istiyorsan kullanmalısın." },
        { "IStepBackText", "Bir adim geri git ve tekrar dene. YHer levelled 1 geri gitme hakkin var ve eger kullanmazsan bu hakkin kayıp olacak." },
        { "IDontForgetText", "Unutma! Her levelde en fazla 20 doldurulmamis* kutu birakabilirsin.           Yoksa yeterli sayıda kutu doldurana kadar leveli tekrarlaman gerekecek :)" },
         { "IDontForgetText2", "*Bos ve kilitlenmis kutular dahil." },
        { "NextButtonText", "ileri" },
        { "BackButtonText", "Geri" },
    };
    public Dictionary<string, string> deTextDict = new Dictionary<string, string> {
        { "CreatingBy", "DIESES SPIEL WURDE VON FunTactic GAME ERSTELLT" },
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
        { "IHowToPlayExplanation2", "Jedes Spiel hat eine andere ZielNote zu erreichen." },
        { "FollowPattern", "Folgt dem Muster zum Füllen. Sie können jedes 3. Kästchen auf der geraden Stufe und jedes 2. Kästchen auf der Kreuzstufe anfahren." },
        { "Leaveasless", "Lasst so wenig ungefüllte Kästchen wie möglich übrig, da sie als blockierte Kästchen in den nächsten Schritt übertragen werden." },
        { "RetryGameInfo", "Wiederholt das Spiel vom ersten Level an.  Du verlierst alle deine Daten außer der besten Punktzahl für das ausgewählte Spiel." },
        { "RetryLevelInfo", "Du kannst das Level so oft wiederholen, wie du willst. Verwendet diese Taste vor allem, wenn du ein besseres Levelende wünschst oder die Position der blockierten Kästchen am Levelanfang ändern möchtest." },
        { "IStepBackText", "Geht einen Schritt zurück und versucht euren Zug erneut. Du hast 1 Schritt zurück Recht für jeden Level und es geht verloren, wenn du es nicht nutzt." },
        { "IDontForgetText", "Vergesst das nicht! Du kannst in jedem Level maximal 20 Kästchen unbesetzt* lassen.           Ansonsten musst du das Level erneut versuchen, bis du genügend Boxen füllst :)" },
        { "IDontForgetText2", "*Leere und  blockierte Boxen zusammen." },
        { "NextButtonText", "Voran" },
        { "BackButtonText", "Zuruck" },
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
