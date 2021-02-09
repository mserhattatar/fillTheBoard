using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanelManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject InfoPanelPage1;
    public GameObject InfoPanelPage2;
    public GameObject InfoPanelPage3;

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
    private int Hile = 0;
    private int FullReset = 0;



    private void Start()
    {
        OpenNewGameButton();
    }  

    private void OpenNewGameButton()
    {//check if player write enough number for open next game; open onclick and icon
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


    //Button on click func
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
        InfoPanelPage1.SetActive(true);
    }
    public void CloseInfoPanel()
    {
        InfoPanel.SetActive(false);
        InfoPanelPage1.SetActive(false);
    }
    public void InfoPanelNextPage2()
    {
        InfoPanelPage2.SetActive(true);
    }
    public void InfoPanelNextPage3()
    {
        InfoPanelPage3.SetActive(true);
    }   
    public void InfoPanelBackPage1()
    {
        InfoPanelPage2.SetActive(false);
    }
    public void InfoPanelBackPage2()
    {
        InfoPanelPage3.SetActive(false);
    }  
    public void CloseAllInfoPanel()
    {
        InfoPanelBackPage2();
        InfoPanelBackPage1();
        CloseInfoPanel();
    }
    //Hile
    public void SerhatButton()
    {
        if (LanguageManager.instance.selectedLang == 1)
        {
            Hile += 1;
            if (Hile > 5)
            {
                SerhatText.text = "MST";
                GameManager.instance.SerhatHile(10, 990);
                GameManager.instance.SerhatHile(9, 800);
                GameManager.instance.SerhatHile(8, 630);
                GameManager.instance.SerhatHile(7, 480);
            }

        }
        else if (LanguageManager.instance.selectedLang == 2)
        {
            FullReset += 1;
            if (FullReset > 5)
            {
                SerhatText.text = "reset";
                GameManager.instance.ResetGameDataDict();
            }
        }
        else
            return;       
    }
}
