using UnityEngine;

public class MainMenuPanelManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject MainMenu;

    public void OpenMainMenuPanel()
    {
        MainMenu.SetActive(true);
    }
    public void CloseMainMenuPanel()
    {
        MainMenu.SetActive(false);
    }
    public void OpenInfoPanel()
    {
        InfoPanel.SetActive(true);
    }
    public void CloseInfoPanel()
    {
        InfoPanel.SetActive(false);
    }
}
