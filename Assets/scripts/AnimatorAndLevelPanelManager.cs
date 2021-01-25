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

        // player dont have next target box for write
        if (activeButtonTargetCount <= 0)
        {
            // Player filled enough boxes to complete the level
            if (ButtonListManager.instance.WriteList.Count >= _minWriteNumberForNextLevel)
            {
                //still have step back button
                if (GetComponent<BackButtonManager>().stepBackButtonCount > 0)
                    FindObjectOfType<BackButtonManager>().StepBackAnimation(true);
                else
                    CompleateLevelStartNewGameOrLevel();
            }
            // player did not fill enough boxes to compleate level But still have steap back button
            else if (GetComponent<BackButtonManager>().stepBackButtonCount > 0)
                FindObjectOfType<BackButtonManager>().StepBackAnimation(true);
            else
            {
                gameOverPanel.SetActive(true);
                _GameOverAni.SetBool("isGameOver", true);                
            }
        }     
        // player has target, filled enough number
        else if (ButtonListManager.instance.WriteList.Count == _minWriteNumberForNextLevel)
        {           
            Instantiate(Confetti, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            completeLevelIcon.SetActive(true);
        }
    }

    public void CompleateLevelStartNewGameOrLevel()
    {
        if (!completeLevelIcon.activeInHierarchy)
        {
            completeLevelIcon.SetActive(true);
        }
        
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
