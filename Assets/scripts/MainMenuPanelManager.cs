using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanelManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject MainMenu;
    public GameObject infoPanelButton;

    public GameObject Button8x8;
    public GameObject Button9x9;
    public GameObject Button10x10;

    public GameObject Compleate7x7;
    public GameObject Compleate8x8;
    public GameObject Compleate9x9;
    public GameObject Compleate10x10;

    public Text SerhatText;
    private int Serhatint = 0;



    private void Start()
    {       
        var data = GameManager.instance.gameData;

        if (data.bestScoreNumberDictionary[10] >= 1000)
        {
            Compleate10x10.SetActive(true);
        }
        if (data.bestScoreNumberDictionary[9] >= 810)
        {
            Button10x10.GetComponent<Button>().interactable = true;
            Compleate9x9.SetActive(true);
        }
        if (data.bestScoreNumberDictionary[8] >= 640)
        {
            Button9x9.GetComponent<Button>().interactable = true;
            Compleate8x8.SetActive(true);
        }       
        if (data.bestScoreNumberDictionary[7] >= 490)
        {
            Button8x8.GetComponent<Button>().interactable = true;
            Compleate7x7.SetActive(true);
        }       
    }  
    public void InfoPanelButtonAni()
    {
        infoPanelButton.GetComponent<Animator>().SetBool("infoButton", true);
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


    public void SerhatButton()
    {
        if (LanguageManager.instance.selectedLang != 1) return;
        Serhatint += 1;
        if(Serhatint > 20)
        {
            SerhatText.text = "4";
            GameManager.instance.SerhatHile(10, 990);
        }
        else if (Serhatint > 15)
        {
            SerhatText.text = "3";
            GameManager.instance.SerhatHile(9, 800);
        }
        else if (Serhatint > 10)
        {
            SerhatText.text = "2";
            GameManager.instance.SerhatHile(8, 630);
        }
        else if (Serhatint > 5)
        {
            SerhatText.text = "1";
            GameManager.instance.SerhatHile(7, 480);
        }
    }
}
