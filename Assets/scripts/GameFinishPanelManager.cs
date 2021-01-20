using UnityEngine;

public class GameFinishPanelManager : MonoBehaviour
{
    
    public void CloseGameFinishPanel()
    {
        this.gameObject.SetActive(false);
    }
    public void KeepGoing()
    {
        LevelManager.instance.NextScene();
    }
    public void NextGame()
    {
        LevelManager.instance.NextGame();
    }
}
