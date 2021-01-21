using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuText : MonoBehaviour
{
    public bool langChanged = false;

    public Text CreatingBy;
    public Text IBackButton;
    public Text IMainMenuText;
    public Text IRetryGameText;
    public Text IRetryLevelText;
    public Text IStepBackText;
    public Text IEvery2Nd;
    public Text IEvery3Nd;
    public Text I5EmptyBoxesText;
    public Text I5BlockedBoxesText;
    public Text IDontForgetText;
    public Text IDontForgetText2;
    public TextMeshProUGUI IHowToPlay;


    private void Update()
    {
        if (langChanged)
        {
            langChanged = false;
            SetTranslatedTextToObject();
        }
    }

    private void Start()
    {
        SetTranslatedTextToObject();
    }
    private void SetTranslatedTextToObject()
    {
        var CTex = LanguageManager.instance;
        CTex.TranslateText(CreatingBy, "THİS GAME CREATİNG   TATAR GAME" , "BU OYUN TATAR GAME TARAFINDAN OLUŞTURULMUSTUR");
        CTex.TranslateText(IBackButton, "Back", "Geri");
        CTex.TranslateText(IMainMenuText, "Main Menu", "Ana Menu");
        CTex.TranslateText(IRetryGameText, "Try Again From Sarting Level 1", " Oyunu Tekrar 1.Level'dan Dene");
        CTex.TranslateText(IRetryLevelText, "Try Again The Level", "Bu Level ı tekrarla");
        CTex.TranslateText(IStepBackText, "You Have 1 Step Back Right For Every Level", "Her Level'da Bir Yazılmıs kutuyu Geri Alma Hakkın Var");

        CTex.TranslateText(IEvery2Nd, "Every 3rd Box", " 3 Kutu Ardından Yazılabilir");
        CTex.TranslateText(IEvery3Nd, "Every 2nd Box", "2 Kutu Ardından Yazılabilir");
        CTex.TranslateText(I5EmptyBoxesText, "5 Empty Boxes", "5 Bos Kutu");
        CTex.TranslateText(I5BlockedBoxesText, "5 Blocked Boxes", " 5 Kilitlenmis kutu");
        CTex.TranslateText(IDontForgetText, "Don't Forget! You Can leave only 20 unfilled* boxes  per level.", "Unutma! Her Levelda Sadece 20 Kutu Boş Bırakabilirsin.");
        CTex.TranslateText(IDontForgetText, "*Empty and blocked boxes together.", "*Bos ve Kilitlenmiş Kutular Dahil.");
        CTex.TranslateTextMesh(IHowToPlay, "HOW TO PLAY", "NASIL OYNANIR");

    }
}
