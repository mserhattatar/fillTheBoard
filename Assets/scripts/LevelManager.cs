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
    public Text fakeLevelNumberUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fakeLevelNumberUI.text = GameManager.instance.fakeLevelNumber.ToString();
    }
   
    public void SetNextLevel(int activeButtonCount)
    {
    // TODO remove comment
        Debug.Log("çalıştı // count= " + activeButtonCount);
        if (activeButtonCount <= 0 && !_levelFinish)
        {
        // TODO remove comment
            Debug.Log("if çalıştı " + activeButtonCount);
            nextLevelButton.gameObject.SetActive(true);
            _levelFinish = true; 
        }
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
