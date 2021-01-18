using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private bool _levelFinish;
    private Animator _NextLEvelAni;
    private Animator _GameOverAni;
    private int _minWriteNumberForNextLevel;
    private bool _confettiAdded;

    public GameObject completeLevelIcon;
    public GameObject Confetti;
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
        fakeLevelNumberUI.text = GameManager.instance.levelNumberToDisplay.ToString();
        bestScore.text = GameManager.instance.bestScoreNumber.ToString();
        _NextLEvelAni = nextLevelPanel.GetComponent<Animator>();
        _GameOverAni = gameOverPanel.GetComponent<Animator>();
        _minWriteNumberForNextLevel = (ButtonListManager.instance.Button1.Count * ButtonListManager.instance.Button1.Count) -20;       
    }

   
    public void SetNextLevel(int activeButtonCount)
    {
        if(ButtonListManager.instance.WriteList.Count >= 2)
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


        //int levelNumber = SceneManager.GetActiveScene().buildIndex;
        //if (1 == SceneManager.sceneCountInBuildSettings)
        //    SceneManager.LoadScene(0);
        //else
        //    SceneManager.LoadScene(1);
    }
    
    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetGame()
    {
        GameManager.instance.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(0);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
