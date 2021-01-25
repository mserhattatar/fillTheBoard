using UnityEngine;
using UnityEngine.UI;
public class AnimatorAndLevelPanelManager : MonoBehaviour
{
    public static AnimatorAndLevelPanelManager instance;

    private int _minWriteNumberForNextLevel;
    private bool _youWinGame = false;

    private Animator _NextLEvelAni;
    private Animator _GameOverAni;
    private Animator _GameFinishAni;
    private Animator _YouWinAni;

    public GameObject nextLevelPanel;
    public GameObject gameOverPanel;
    public GameObject gameFinishPanel;
    public GameObject youWinPanel;
    public Text youWinNumberText;

    public GameObject completeLevelIcon;
    public GameObject Confetti;
    public GameObject ConfettiBurst;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetAniCompenent();
        _minWriteNumberForNextLevel = (ButtonListManager.instance.Button1.Count * ButtonListManager.instance.Button1.Count) - 20;
    }
    private void SetAniCompenent()
    {
        _NextLEvelAni = nextLevelPanel.GetComponent<Animator>();
        _GameOverAni = gameOverPanel.GetComponent<Animator>();
        _GameFinishAni = gameFinishPanel.GetComponent<Animator>();
        _YouWinAni = youWinPanel.GetComponent<Animator>();
    }

    public void CheckLevelCompleateOrNot(int activeButtonTargetCount)
    {
        CheckWriteNumberEnoughforYouWinGamePanel();

        //if player dont have next target box for write
        if (activeButtonTargetCount <= 0)
        {
            // Check Player Write enough number for compleate level
            if (ButtonListManager.instance.WriteList.Count >= _minWriteNumberForNextLevel)
            {
                //if Player write enough number for compleate level and  dont have rational boxes for come back and change write 
                var writeList = ButtonListManager.instance.WriteList;               
                var secondButton = writeList[writeList.Count - 2].GetComponent<ButtonController>().targetButtonList.Count;                
                if (secondButton == 1)
                {
                    CompleateLevelStartNewGameOrLevel();
                }

                //still have steap back button
                else if (GetComponent<BackButtonManager>().stepBackButtonCount > 0)
                {
                    FindObjectOfType<BackButtonManager>().StepBackAnimation(true);
                }

                //if player dont have next target box for write,  Write enough number for compleate level and have not steap back button
                else
                {
                    CompleateLevelStartNewGameOrLevel();
                }
            }
          
            //if player dont have next target box for write and not enough number to compleate level But still have steap back button
            else if (GetComponent<BackButtonManager>().stepBackButtonCount > 0)
            {
                FindObjectOfType<BackButtonManager>().StepBackAnimation(true);
            }
            //  But have not steap back button
            else
            {
                gameOverPanel.SetActive(true);
                _GameOverAni.SetBool("isGameOver", true);                
            }
        }     
        // if player write enough number. create confetti and open complete level icon
        else if (ButtonListManager.instance.WriteList.Count == _minWriteNumberForNextLevel)
        {           
            Instantiate(Confetti, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            completeLevelIcon.SetActive(true);
        }
    }

    public void CompleateLevelStartNewGameOrLevel()
    {
        //if Player write enough number for open nex level but also you write enough number for open new game matrix, open the new game panel  
        if (_youWinGame)
        {
            OpenNewGamePanel();
            return;
        }
        //open the next level panel
        nextLevelPanel.SetActive(true);
        _NextLEvelAni.SetBool("isNextLevel", true);       
    }

    //You Win Panel
    public void CheckWriteNumberEnoughforYouWinGamePanel()
    {
        var LevelButtonMatrix = ButtonManager.instance.LevelButtonMatrix;
        var numberToDisplay = ButtonManager.instance.numberToDisplay;

        if (LevelButtonMatrix == 10 && numberToDisplay == 1000)
        {
            YouWinGamePanel(numberToDisplay);
            _youWinGame = true;
        }
        if (LevelButtonMatrix == 9 && numberToDisplay == 810)
        {
            YouWinGamePanel(numberToDisplay);
            _youWinGame = true;
        }
        if (LevelButtonMatrix == 8 && numberToDisplay == 640)
        {

            YouWinGamePanel(numberToDisplay);
            _youWinGame = true;
        }
        if (LevelButtonMatrix == 7 && numberToDisplay == 490)
        {

            YouWinGamePanel(numberToDisplay);
            _youWinGame = true;
        }       
    }
    private void YouWinGamePanel(int number)
    {
        youWinPanel.SetActive(true);
        youWinNumberText.text = number.ToString();
        _YouWinAni.SetBool("YouWinAni", true);
        Instantiate(ConfettiBurst, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(ConfettiBurst, new Vector3(0, -5, 0), Quaternion.Euler(0, 0, 0));
    }
   
    //Game FinishPanel
    private void OpenNewGamePanel()
    {
        var LevelButtonMatrix = ButtonManager.instance.LevelButtonMatrix;

        if (LevelButtonMatrix == 10)
        {
            GameFinishPanelAni("AniFinish");
        }
        if (LevelButtonMatrix == 9)
        {
            GameFinishPanelAni("Ani10x10");
        }
        if (LevelButtonMatrix == 8)
        {
            GameFinishPanelAni("Ani9x9");
        }
        if (LevelButtonMatrix == 7)
        {
            GameFinishPanelAni("Ani8x8");
        }

    }
    private void GameFinishPanelAni(string aniName)
    {
        gameFinishPanel.SetActive(true);
        _GameFinishAni.SetBool(aniName, true);
        Instantiate(ConfettiBurst, new Vector3(0, -6, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(ConfettiBurst, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
    }

    
}
