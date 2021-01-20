using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Text bestScore;   
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
    } 

    //Butoons Fonction
    public void NextScene()
    {
        GameManager.instance.LevelComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextGame()
    {
        GameManager.instance.LevelComplete();
        SceneManager.LoadScene(0);
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
