using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int number;
    public int emptyButtonAmountAtLevelEnd;    
    public int fakeLevelNumber;
    public int bestScoreNumber;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);            
        }
        else
        {
            Destroy(gameObject);
        }
        Application.runInBackground = true;
        number = 1;
        fakeLevelNumber= 1;
        bestScoreNumber = 0;
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

    public void SetNumber()
    {
        number = ButtonManager.instance.number;
        if(bestScoreNumber < number)
        {
            bestScoreNumber = number - 1;
        }        
        MinNumberForNextLevel();
        SaveGameNow();
    }
    public void SaveGameNow()
    {
        SaveSysteam.SaveGame(this);
    }

    public void GetvalueFromGameData()
    {
        GameData data = SaveSysteam.LoadGame();
        number = data.number;
        fakeLevelNumber = data.fakeLevelNumber;
        emptyButtonAmountAtLevelEnd = data.emptyButtonCount;
        bestScoreNumber = data.bestCoreNumber;
    }


    private void MinNumberForNextLevel()
    {
      
        fakeLevelNumber += 1;
    }

}
