using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public int numberToDisplay = 1;
    [HideInInspector]
    public int emptyButtonAmountAtLevelEnd = 0;    
    [HideInInspector]
    public int levelNumberToDisplay = 1;
    [HideInInspector]
    public int bestScoreNumber = 0;
    
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
            return;
        }
        
        //Application.runInBackground = true;
        
        // Set 
        //numberToDisplay = 1;
        //levelNumberToDisplay = 1;
        //bestScoreNumber = 0;
        
        GetvalueFromGameData();
    }
    //private void Update()
    //{
    //    if (!Application.runInBackground)
    //    {
    //        Application.runInBackground = true;
    //    }
    //}
    //private void Start()
    //{
    //    Debug.Log("numberToDisplay" + numberToDisplay );
    //}

    public void ResetGame()
    {
       numberToDisplay = 1;
       levelNumberToDisplay = 1;
       emptyButtonAmountAtLevelEnd = 0;
       SaveGameNow();

    }
    public void LevelComplete()
    {
        numberToDisplay = ButtonManager.instance.number;
        SetBestScore();
        levelNumberToDisplay += 1;
        ButtonManager.SetEmptyButtonAmount();
        SaveGameNow();
    }
    private void SetBestScore()
    {
        if (bestScoreNumber < numberToDisplay)
        {
            bestScoreNumber = numberToDisplay - 1;
        }
    }
    public void SaveGameNow()
    {
        SaveSysteam.SaveGame(this);
    }       
    public void GetvalueFromGameData()
    {
        GameData data = SaveSysteam.LoadGame();
        numberToDisplay = data.numberToDisplay;
        levelNumberToDisplay = data.levelNumberToDisplay;
        emptyButtonAmountAtLevelEnd = data.emptyButtonCount;
        bestScoreNumber = data.bestCoreNumber;
    }
}
