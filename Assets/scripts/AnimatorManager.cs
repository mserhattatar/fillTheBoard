using UnityEngine;
using UnityEngine.UI;
public class AnimatorManager : MonoBehaviour
{
    public static AnimatorManager instance;

    private bool _levelFinish;
    private int _minWriteNumberForNextLevel;
    private bool _confettiAdded;
    private bool _youWinGame = false;

    private Animator _NextLEvelAni;
    private Animator _GameOverAni;
    private Animator _GameFinishAni;
    private Animator _YouWinAni;

    public GameObject nextLevelPanel;
    public GameObject gameOverPanel;
    public GameObject gameFinishPanel;
    public GameObject youWinPanel;
    public Text youWinNumberText;

    public GameObject completeLevelIcon;
    public GameObject Confetti;
    public GameObject ConfettiBurst;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _NextLEvelAni = nextLevelPanel.GetComponent<Animator>();
        _GameOverAni = gameOverPanel.GetComponent<Animator>();
        _GameFinishAni = gameFinishPanel.GetComponent<Animator>();
        _YouWinAni = youWinPanel.GetComponent<Animator>();

        _minWriteNumberForNextLevel = (ButtonListManager.instance.Button1.Count * ButtonListManager.instance.Button1.Count) - 20;
    }
  
    public void IsFinishGamiAni()
    {
        var LevelButtonMatrix = ButtonManager.instance.LevelButtonMatrix;
        var numberToDisplay = ButtonManager.instance.numberToDisplay;

        if (LevelButtonMatrix == 10 && numberToDisplay == 1000)
        {
            GameYouWinPanel(numberToDisplay);
            _youWinGame = true;
        }
        if (LevelButtonMatrix == 9 && numberToDisplay == 810)
        {
            GameYouWinPanel(numberToDisplay);
            _youWinGame = true;
        }
        if (LevelButtonMatrix == 8 && numberToDisplay == 640)
        {

            GameYouWinPanel(numberToDisplay);
            _youWinGame = true;
        }
        if (LevelButtonMatrix == 7 && numberToDisplay == 490)
        {

            GameYouWinPanel(numberToDisplay);
            _youWinGame = true;
        }       
    }
    private void GameYouWinPanel(int number)
    {
        youWinPanel.SetActive(true);
        youWinNumberText.text = number.ToString();
        _YouWinAni.SetBool("YouWinAni", true);
        Instantiate(ConfettiBurst, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(ConfettiBurst, new Vector3(0, -5, 0), Quaternion.Euler(0, 0, 0));
    }
   
    private void GameFinishAniFonction1()
    {
        var LevelButtonMatrix = ButtonManager.instance.LevelButtonMatrix;

        if (LevelButtonMatrix == 10)
        {
            GameFinishAniFonction2("AniFinish");
        }
        if (LevelButtonMatrix == 9)
        {
            GameFinishAniFonction2("Ani10x10");
        }
        if (LevelButtonMatrix == 8)
        {
            GameFinishAniFonction2("Ani9x9");
        }
        if (LevelButtonMatrix == 7)
        {
            GameFinishAniFonction2("Ani8x8");
        }

    }
    private void GameFinishAniFonction2(string aniName)
    {
        gameFinishPanel.SetActive(true);
        _GameFinishAni.SetBool(aniName, true);
        Instantiate(ConfettiBurst, new Vector3(0, -6, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(ConfettiBurst, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    public void SetNextLevel(int activeButtonCount)
    {
        IsFinishGamiAni();

        if (ButtonListManager.instance.WriteList.Count >= 2)
        {
            var writeList = ButtonListManager.instance.WriteList;
            var firstButton = writeList[writeList.Count - 1].GetComponent<ButtonController>().targetButtonList.Count;
            var secondButton = writeList[writeList.Count - 2].GetComponent<ButtonController>().targetButtonList.Count;

            if (firstButton <= 0 && secondButton <= 1)
            {
                if (_youWinGame)
                {
                    GameFinishAniFonction1();
                    return;
                }
                nextLevelPanel.SetActive(true);
                _NextLEvelAni.SetBool("isNextLevel", true);
                _levelFinish = true;
            }
        }
        if (activeButtonCount <= 0 && !_levelFinish && ButtonListManager.instance.WriteList.Count >= _minWriteNumberForNextLevel && GetComponent<BackButtonManager>().backButtonCount2 > 0)
        {
            FindObjectOfType<BackButtonManager>().StepBackAnimation();
        }
        else if (activeButtonCount <= 0 && !_levelFinish && ButtonListManager.instance.WriteList.Count >= _minWriteNumberForNextLevel)
        {
            if (_youWinGame)
            {
                GameFinishAniFonction1();
                return;
            }
            nextLevelPanel.SetActive(true);
            _NextLEvelAni.SetBool("isNextLevel", true);
            _levelFinish = true;
        }
        else if (activeButtonCount <= 0 && !_levelFinish && GetComponent<BackButtonManager>().backButtonCount2 > 0)
        {
            FindObjectOfType<BackButtonManager>().StepBackAnimation();
        }
        else if (activeButtonCount <= 0 && !_levelFinish && GetComponent<BackButtonManager>().backButtonCount2 <= 0)
        {
            gameOverPanel.SetActive(true);
            _GameOverAni.SetBool("isGameOver", true);
            _levelFinish = true;
        }
        else if (!_confettiAdded && ButtonListManager.instance.WriteList.Count >= _minWriteNumberForNextLevel)
        {
            _confettiAdded = true;
            Instantiate(Confetti, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            completeLevelIcon.SetActive(true);
        }
    }
}
