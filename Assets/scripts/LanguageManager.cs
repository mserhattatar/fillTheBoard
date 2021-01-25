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
        { "CreatingBy", "THIS GAME IS CREATED BY FunTactic GAMES" },
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
        { "Leaveasless", "Leave as few unfilled boxes as possible because they will be transferred to the next level as blocked boxes." },
        { "RetryGameInfo", "Retry current game from starting first level. You will lose current game data except the best score" },
        { "RetryLevelInfo", "Retry current level as many times as you want. Use this button especially if you want a better level end or want to change the position of the blocked boxes at the level start." },
        { "IStepBackText", "Take a step back and try your move again. You have 1 Step Back Right For Every Level and it is lost if you don't use it." },
        { "IDontForgetText", "Don't Forget! You Can leave maximum 20 unfilled* boxes  in each level. Otherwise you need to retry the level until you fill enough boxes :)" },
        { "IDontForgetText2", "*Empty and blocked boxes together." },
        { "NextButtonText", "Next" },
        { "BackButtonText", "Back" },
        { "CloseButtonText", "CLOSE" }
        
    };
    public Dictionary<string, string> trTextDict = new Dictionary<string, string> {
        { "CreatingBy", "BU OYUN FunTactic GAMES TARAFINDAN OLUŞTURULMUŞTUR" },
        { "IBackButton", "Geri" },
        { "IEvery3rd", "Her 3. kutu" },
        { "IEvery2nd", "Her 2. kutu" },
        { "I5EmptyBoxesText", "5 Boş Kutu" },
        { "I5BlockedBoxesText", "5 Kilitlenmiş kutu" },
        { "IHowToPlay", "NASIL OYNANIR?" },
        { "FinishTheLevel", "Tebrikler!             Oyunu Kazandın" },
        { "RetryLevel", "LEVELİ YENİLE" },
        { "RetryGame", "OYUNU YENİLE" },
        { "StepBack", "GERİ AL" },
        { "BestScore", "En iyi Skor" },
        { "BestLevel", "Skor Leveli" },
        { "NextLevel", "SONRAKİ LEVEL" },
        { "YouWin", "LEVELİ BİTİR VE OYUNU KAZAN!" },
        { "IGameTarget",          "Oyun          Hedef Skor" },
        { "IGameTargetUnderline", "_____         ___________" },
        { "MainMenu", "Ana Menü" },
        { "IHowToPlayExplanation", "Kutuları doldur, hedefe ulaş ve sonraki oyuna geç" },
        { "IHowToPlayExplanation2", "Her oyunun farklı bir hedef skoru var." },
        { "FollowPattern", "Kutuları doldurmak için deseni izle. Düz adımlarda her 3. Kutuya, çapraz adımlarda her 2. Kutuya gidebilirsin." },
        { "Leaveasless", "Olabildiğince az boş kutu bırak çünkü doldurulmamış kutular sonraki levele bloklanmış olarak aktarılacak." },
        { "RetryGameInfo", "İlk levelden başlayarak seçili oyunu yeniden dene. En iyi skor hariç bu oyuna ait verilerini kaybedeceksin." },
        { "RetryLevelInfo", "Leveli istediğin kadar yeniden dene. Bu butonu özellikle daha iyi bir level sonu başarısı istiyorsan yada level başında bloklanmış kutuların pozisyonunu değiştirmek istiyorsan kullanabilirsin." },
        { "IStepBackText", "Bir adım geri git ve tekrar dene. Her levelde 1 adet geri gitme hakkın var ve eğer kullanmazsan bu hakkın kayıp olacak." },
        { "IDontForgetText", "Unutma! Her levelde en fazla 20 doldurulmamış* kutu bırakabilirsin. Yoksa yeterli sayıda kutu doldurana kadar leveli tekrarlaman gerekecek :)" },
        { "IDontForgetText2", "*Boş ve kilitlenmiş kutular dahil." },
        { "NextButtonText", "ileri" },
        { "BackButtonText", "Geri" },
         { "CloseButtonText", "KAPAT" }
    };
    public Dictionary<string, string> deTextDict = new Dictionary<string, string> {
        { "CreatingBy", "DIESES SPIEL WURDE VON FunTactic GAMES ERSTELLT" },
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
        { "RetryGameInfo", "Wiederholt das Spiel vom ersten Level an. Du verlierst alle deine Daten außer der besten Punktzahl für das ausgewählte Spiel." },
        { "RetryLevelInfo", "Du kannst das Level so oft wiederholen, wie du willst. Verwendet diese Taste vor allem, wenn du ein besseres Levelende wünschst oder die Position der blockierten Kästchen am Levelanfang ändern möchtest." },
        { "IStepBackText", "Geht einen Schritt zurück und versucht euren Zug erneut. Du hast 1 Schritt zurück Recht für jeden Level und es geht verloren, wenn du es nicht nutzt." },
        { "IDontForgetText", "Vergesst das nicht! Du kannst in jedem Level maximal 20 Kästchen unbesetzt* lassen. Ansonsten musst du das Level erneut versuchen, bis du genügend Boxen füllst :)" },
        { "IDontForgetText2", "*Leere und  blockierte Boxen zusammen." },
        { "NextButtonText", "Voran" },
        { "BackButtonText", "Zurück" },
        { "CloseButtonText", "SCHLIEßEN" }
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
    //Set Language from gamedata
    public void initLayoutManager()
    {
        selectedLang = GameManager.instance.gameData.selectedLang;
        updateSelectedLang(false);
        langDropdown.GetComponent<Dropdown>().value = selectedLang;
    }

    //Lang Dropdown Button on click func from mainmenu sceene
    public void updateSelectedLang(bool buttonclick = true)
    {
        int value;       
        if (buttonclick)
        {// if player changed lang with dropdown button from mainmenu sceene
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
    {// save and update mainmenutext Texts
        GameManager.instance.SaveSelectedLanguage();
        FindObjectOfType<MainMenuText>().langChanged = true;
    }
}
