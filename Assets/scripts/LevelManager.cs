using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private bool _levelFinish;
    private Animator _NextLEvelAni;
    private Animator _GameOverAni;
    private Animator _GameFinishAni;
    private int _minWriteNumberForNextLevel;
    private bool _confettiAdded;

    public GameObject completeLevelIcon;
    public GameObject Confetti;
    public GameObject Confetti2;   
    public Text bestScore;
    public GameObject nextLevelPanel;
    public GameObject gameOverPanel;
    public GameObject gameFinishPanel;
    [HideInInspector]   
    public Text fakeLevelNumberUI;    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fakeLevelNumberUI.text = GameManager.instance.gameData.levelNumberToDisplayDictionary[ButtonManager.instance.LevelButtonMatrix].ToString();
        bestScore.text = GameManager.instance.gameData.bestScoreNumberDictionary[ButtonManager.instance.LevelButtonMatrix].ToString();
        _NextLEvelAni = nextLevelPanel.GetComponent<Animator>();
        _GameOverAni = gameOverPanel.GetComponent<Animator>();
        _GameFinishAni = gameFinishPanel.GetComponent<Animator>();
        _minWriteNumberForNextLevel = (ButtonListManager.instance.Button1.Count * ButtonListManager.instance.Button1.Count) -20;       
    }
    private void IsFinishGamiAni() 
    {
        var LevelButtonMatrix = ButtonManager.instance.LevelButtonMatrix;
        var numberToDisplay = ButtonManager.instance.numberToDisplay;

        if (LevelButtonMatrix == 10 && numberToDisplay == 1000)
        {
            gameFinishPanel.SetActive(true);
            _GameFinishAni.SetBool("AniFinish", true);
            Instantiate(Confetti2, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

        }
        if (LevelButtonMatrix == 9 && numberToDisplay == 810)
        {
            gameFinishPanel.SetActive(true);
            _GameFinishAni.SetBool("Ani10x10", true);
            Instantiate(Confetti2, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));

        }
        if (LevelButtonMatrix == 8 && numberToDisplay == 640)
        {
            gameFinishPanel.SetActive(true);
            _GameFinishAni.SetBool("Ani9x9", true);
            Instantiate(Confetti2, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        }
        if (LevelButtonMatrix == 7 && numberToDisplay == 490)
        {
            gameFinishPanel.SetActive(true);
            _GameFinishAni.SetBool("Ani8x8", true);
            Instantiate(Confetti2, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        }
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
            Instantiate(Confetti,new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            completeLevelIcon.SetActive(true);
        }
    }   

    //Butoons Fonction
    public void NextScene()
    {
        GameManager.instance.LevelComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetGame()
    {
        GameManager.instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
