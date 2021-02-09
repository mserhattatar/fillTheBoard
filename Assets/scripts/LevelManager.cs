using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject ResetGamePanel;

    private void Awake()
    {
        instance = this;
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
    public void OpenResetGamePanel()
    {
        var LevelMatrix = ButtonListManager.instance.Button1.Count;
        var fakeLevelNumber = GameManager.instance.gameData.levelNumberToDisplayDictionary[LevelMatrix];

        if (fakeLevelNumber ==1 && ButtonListManager.instance.WriteList.Count > 7 || fakeLevelNumber > 1)
            ResetGamePanel.SetActive(true);
        else
            ResetGameNow();
    }
    public void CloseResetGamePanel()
    {
        ResetGamePanel.SetActive(false);
    }
    public void ResetGameNow()
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
