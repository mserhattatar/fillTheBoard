using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public int number;
    [HideInInspector]
    public int emptyButtonAmountAtLevelEnd;    
    [HideInInspector]
    public int fakeLevelNumber;
    [HideInInspector]
    public int bestScoreNumber;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("gamemanger oluştu");
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        Application.runInBackground = true;
        number = 1;
        fakeLevelNumber= 1;
        bestScoreNumber = 0;
        FindObjectOfType<MainMenuPanelManager>().OpenMainMenuPanel();
        Debug.Log("gamemanger çalıştı");

    }

    private void Start()
    {
        GetvalueFromGameData();
    }
    private void Update()
    {
        if (!Application.runInBackground)
        {
            Application.runInBackground = true;
        }
    }

    public void ResetGame()
    {
       number = 1;
       fakeLevelNumber = 1;
       emptyButtonAmountAtLevelEnd = 0;
       SaveGameNow();

    }
    public void LevelComplete()
    {
        number = ButtonManager.instance.number;
        SetBestScore();
        FakeLevelNumberIncrease();
        ButtonManager.SetEmptyButtonAmount();
        SaveGameNow();
    }
    private void SetBestScore()
    {
        if (bestScoreNumber < number)
        {
            bestScoreNumber = number - 1;
        }
    }
    public void SaveGameNow()
    {
        SaveSysteam.SaveGame(this);
    }    
    private void FakeLevelNumberIncrease()
    {      
        fakeLevelNumber += 1;
    }
    public void GetvalueFromGameData()
    {
        GameData data = SaveSysteam.LoadGame();
        number = data.number;
        fakeLevelNumber = data.fakeLevelNumber;
        emptyButtonAmountAtLevelEnd = data.emptyButtonCount;
        bestScoreNumber = data.bestCoreNumber;
    }

}
