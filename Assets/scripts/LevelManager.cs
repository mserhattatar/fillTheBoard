using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private bool _levelFinish;

    public static LevelManager instance;
    public int minNumberForNextLevel;
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
        bestScore.text = GameManager.instance.number.ToString();
    }
   
    public void SetNextLevel(int activeButtonCount)
    {    
        if (activeButtonCount <= 0 && !_levelFinish && ButtonListManager.instance.WriteList.Count >= minNumberForNextLevel)
        {
            nextLevelPanel.gameObject.SetActive(true);
            _levelFinish = true; 
        }
        else if (activeButtonCount <= 0 && !_levelFinish && GetComponent<BackButtonManager>().backButtonCount2 <= 0)
        {
            gameOverPanel.gameObject.SetActive(true);
            _levelFinish = true;
        }
    }
    
    
    private static void SetInGameManager()
    {
        GameManager.instance.SetNumber();
        ButtonManager.SetFreeButtonNumbers();
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
        GameManager.instance.emptyButtonCount = 0;
        SceneManager.LoadScene(1);
    }

}
