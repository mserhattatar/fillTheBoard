using UnityEngine;

public class GameFinishPanelAnimatorManager : MonoBehaviour
{
    public GameObject gameFinishPanel;
    
    public void CloseGameFinishPanel()
    {
        gameFinishPanel.SetActive(false);
    }
}
