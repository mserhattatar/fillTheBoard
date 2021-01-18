using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanelManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject MainMenu;

    public GameObject Button8x8;
    public GameObject Button9x9;
    public GameObject Button10x10;

    public GameObject Compleate7x7;
    public GameObject Compleate8x8;
    public GameObject Compleate9x9;
    public GameObject Compleate10x10;



    private void Start()
    {        
        var bestScore = GameManager.instance.bestScoreNumber;

        if (bestScore >= 1000)
        {
            Compleate10x10.SetActive(true);
        }
        if (bestScore >= 810)
        {
            Button10x10.GetComponent<Button>().interactable = true;
            Compleate9x9.SetActive(true);
        }
        else if (bestScore >= 640)
        {
            Button9x9.GetComponent<Button>().interactable = true;
            Compleate8x8.SetActive(true);
        }       
        else if (bestScore >= 490)
        {
            Button8x8.GetComponent<Button>().interactable = true;
            Compleate7x7.SetActive(true);
        }       
    }   

    public void StartGame7x7()
    {
        SceneManager.LoadScene(1);
    }
    public void StartGame8x8()
    {       
        SceneManager.LoadScene(2);
    }
    public void StartGame9x9()
    {
        SceneManager.LoadScene(3);
    }
    public void StartGame10x10()
    {
        SceneManager.LoadScene(4);
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
