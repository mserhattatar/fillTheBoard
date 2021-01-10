using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private bool _levelFinish;
    private int _minNumberForNextLevel;

    public static LevelManager instance;
    public GameObject nextLevelButton;
    [HideInInspector]
    public float levelBarFill;
    public Image levelBar;
    public Text fakeLevelNumberUI;
    public Text minNumberForNextLevelUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        levelBarFill = 0f;
        _minNumberForNextLevel = GameManager.instance.minNumberForNextLevelInt;
        fakeLevelNumberUI.text = GameManager.instance.fakeLevelNumber.ToString();
        minNumberForNextLevelUI.text = _minNumberForNextLevel.ToString();
    }
   

    public void SetNextLevel(int activeButtonCount)
    {
        Debug.Log("çalıştı // count= " + activeButtonCount);
        if (activeButtonCount <= 0 && !_levelFinish)
        {
            Debug.Log("if çalıştı " + activeButtonCount);
            nextLevelButton.gameObject.SetActive(true);
            _levelFinish = true; 
        }
    }
    

    private void LevelBarControl()
    {
        levelBarFill = 1f * ButtonManager.instance.number / _minNumberForNextLevel;
        levelBar.fillAmount = levelBarFill;
    }

    private static void SetInGameManager()
    {
        GameManager.instance.SetNumber();
        ButtonManager.SetFreeButtonNumbers();
        GameManager.instance.SetBackButtonCountNumber();
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
}
