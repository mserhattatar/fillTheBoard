using UnityEngine;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour
{
    public bool langChanged = false;

    public Text CreatingBy;
    public Text IBackButton;
    public Text IRetryGame;
    public Text IRetryLevel;
    public Text IStepBack;    
    public Text IEvery2nd;
    public Text IEvery3rd;
    public Text I5EmptyBoxesText;
    public Text I5BlockedBoxesText;
    public Text IDontForgetText;
    public Text IDontForgetText2;
    public Text IHowToPlay;
    public Text IHowToPlayExplanation; 
    public Text IHowToPlayExplanation2;
    public Text INextLevelText;
    public Text IGameTarget;
    public Text IGameTargetUnderline;
    public Text FollowPattern;
    public Text Leaveasless;
    public Text IStepBackText;
    public Text RetryGameInfo;
    public Text RetryLevelInfo;
    public Text BackButtonText;
    public Text BackButtonText1;
    public Text BackButtonText2;
    public Text NextButtonText;
    public Text NextButtonText1;
    public Text CloseButtonText;



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
        IRetryGame.text = CText.getTranslatedTextOf("RetryGame");
        IRetryLevel.text = CText.getTranslatedTextOf("RetryLevel");
        CreatingBy.text = CText.getTranslatedTextOf("CreatingBy");
        IBackButton.text = CText.getTranslatedTextOf("IBackButton");       
        IStepBackText.text = CText.getTranslatedTextOf("IStepBackText");
        IStepBack.text = CText.getTranslatedTextOf("StepBack");        
        IEvery3rd.text = CText.getTranslatedTextOf("IEvery3rd");
        IEvery2nd.text = CText.getTranslatedTextOf("IEvery2nd");
        I5EmptyBoxesText.text = CText.getTranslatedTextOf("I5EmptyBoxesText");
        I5BlockedBoxesText.text = CText.getTranslatedTextOf("I5BlockedBoxesText");
        IDontForgetText.text = CText.getTranslatedTextOf("IDontForgetText");
        IDontForgetText2.text = CText.getTranslatedTextOf("IDontForgetText2");
        IHowToPlay.text = CText.getTranslatedTextOf("IHowToPlay");
        IHowToPlayExplanation.text = CText.getTranslatedTextOf("IHowToPlayExplanation");
        IHowToPlayExplanation2.text = CText.getTranslatedTextOf("IHowToPlayExplanation2");
        INextLevelText.text = CText.getTranslatedTextOf("NextLevel");
        IGameTarget.text = CText.getTranslatedTextOf("IGameTarget");
        IGameTargetUnderline.text = CText.getTranslatedTextOf("IGameTargetUnderline");
        FollowPattern.text = CText.getTranslatedTextOf("FollowPattern");
        Leaveasless.text = CText.getTranslatedTextOf("Leaveasless");
        RetryGameInfo.text = CText.getTranslatedTextOf("RetryGameInfo");
        RetryLevelInfo.text = CText.getTranslatedTextOf("RetryLevelInfo");
        BackButtonText.text = CText.getTranslatedTextOf("BackButtonText");
        BackButtonText1.text = CText.getTranslatedTextOf("BackButtonText");
        BackButtonText2.text = CText.getTranslatedTextOf("BackButtonText");
        NextButtonText.text = CText.getTranslatedTextOf("NextButtonText");
        NextButtonText1.text = CText.getTranslatedTextOf("NextButtonText");
        CloseButtonText.text = CText.getTranslatedTextOf("CloseButtonText");
    }
}
