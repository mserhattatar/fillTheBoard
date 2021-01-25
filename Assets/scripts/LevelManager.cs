using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Text bestScore;
    public Text bestLevel;    
    public Text fakeLevelNumberUI;    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var LevelMatrix = ButtonListManager.instance.Button1.Count;        
        fakeLevelNumberUI.text = GameManager.instance.gameData.levelNumberToDisplayDictionary[LevelMatrix].ToString();
        bestScore.text = GameManager.instance.gameData.bestScoreNumberDictionary[LevelMatrix].ToString();
        bestLevel.text = GameManager.instance.gameData.bestScoreLevelDictionary[LevelMatrix].ToString();
    } 

    //Butoons Fonction
    public void NextScene()
    {
        GameManager.instance.LevelComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        GameManager.instance.LevelComplete();
        SceneManager.LoadScene(0);
    }
    
    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RetryLevelSaveBestScore()
    {
        GameManager.instance.SaveBestScore();
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
    public void OpenNextGame(int whichgame)
    {
        GameManager.instance.LevelComplete();
        SceneManager.LoadScene(whichgame);
    }
}
