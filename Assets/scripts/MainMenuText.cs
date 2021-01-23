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
    public Text IEvery2nd;
    public Text IEvery3rd;
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
        var CText = LanguageManager.instance;

        CreatingBy.text = CText.getTranslatedTextOf("CreatingBy");
        IBackButton.text = CText.getTranslatedTextOf("IBackButton");
        IMainMenuText.text = CText.getTranslatedTextOf("IMainMenuText");
        IRetryGameText.text = CText.getTranslatedTextOf("IRetryGameText");
        IRetryLevelText.text = CText.getTranslatedTextOf("IRetryLevelText");
        IStepBackText.text = CText.getTranslatedTextOf("IStepBackText");


        IEvery3rd.text = CText.getTranslatedTextOf("IEvery3rd");
        IEvery2nd.text = CText.getTranslatedTextOf("IEvery2nd");
        I5EmptyBoxesText.text = CText.getTranslatedTextOf("I5EmptyBoxesText");
        I5BlockedBoxesText.text = CText.getTranslatedTextOf("I5BlockedBoxesText");
        IDontForgetText.text = CText.getTranslatedTextOf("IDontForgetText");
        IDontForgetText2.text = CText.getTranslatedTextOf("IDontForgetText2");
        IHowToPlay.text = CText.getTranslatedTextOf("IHowToPlay");

    }
}
