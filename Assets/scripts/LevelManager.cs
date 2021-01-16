using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private bool _levelFinish;
    private Animator _NextLEvelAni;
    private Animator _GameOverAni;
    private int _minWriteNumberForNextLevel;


    public static LevelManager instance;
    public Text bestScore;
    public GameObject nextLevelPanel;
    public GameObject gameOverPanel;
    [HideInInspector]   
    public Text fakeLevelNumberUI;

    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fakeLevelNumberUI.text = GameManager.instance.fakeLevelNumber.ToString();
        bestScore.text = GameManager.instance.bestScoreNumber.ToString();
        _NextLEvelAni = nextLevelPanel.GetComponent<Animator>();
        _GameOverAni = gameOverPanel.GetComponent<Animator>();

        _minWriteNumberForNextLevel = 20;
        if (GameManager.instance.fakeLevelNumber > 6)
        {
            _minWriteNumberForNextLevel = 30;
            if(GameManager.instance.fakeLevelNumber > 9)
            {
                _minWriteNumberForNextLevel = 35;
            }
        }
    }
   
    public void SetNextLevel(int activeButtonCount)
    {
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
    }
    
    
    private static void SetInGameManager()
    {
        GameManager.instance.SetNumber();
        ButtonManager.SetEmptyButtonAmount(); 
    }

    public void NextScene()
    {
        SetInGameManager();
        int levelNumber = SceneManager.GetActiveScene().buildIndex;
        if (levelNumber + 1 == SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(levelNumber + 1);
    }
    
    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetGame()
    {
        GameManager.instance.number = 1;
        GameManager.instance.fakeLevelNumber = 1;
        GameManager.instance.emptyButtonAmountAtLevelEnd = 0;       
        SceneManager.LoadScene(1);
    }

}
