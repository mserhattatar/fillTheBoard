using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public GameData gameData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameData = new GameData(this);
            DontDestroyOnLoad(gameObject);
            InitGameDataDict();
        }
        else
        {
            Destroy(gameObject);
            return;
        }       
        GetvalueFromGameData();
    }
   
    private void InitGameDataDict()
    {
        if (gameData.numberToDisplayDictionary.Keys.Count > 0) return;
        foreach (var gameIndex in new List<int> { 7, 8, 9, 10 })
        {
            gameData.numberToDisplayDictionary.Add(gameIndex, 1);
            gameData.emptyButtonAmountAtLevelEndDictionary.Add(gameIndex, 0);
            gameData.levelNumberToDisplayDictionary.Add(gameIndex, 1);
            gameData.bestScoreNumberDictionary.Add(gameIndex, 0);
        }
    }
    public void ResetGame()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;
        gameData.numberToDisplayDictionary[_LevelMatrix] = 1;
        gameData.levelNumberToDisplayDictionary[_LevelMatrix] = 1;
        gameData.emptyButtonAmountAtLevelEndDictionary[_LevelMatrix] = 0;
        SaveGameNow();

    }
    public void LevelComplete()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;
        gameData.numberToDisplayDictionary[_LevelMatrix] = ButtonManager.instance.numberToDisplay;
        SetBestScore();
        gameData.levelNumberToDisplayDictionary[_LevelMatrix] += 1;
        ButtonManager.instance.SetEmptyButtonAmount();
        SaveGameNow();
    }
    private void SetBestScore()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;

        if (gameData.bestScoreNumberDictionary[_LevelMatrix] < gameData.numberToDisplayDictionary[_LevelMatrix])
        {
            gameData.bestScoreNumberDictionary[_LevelMatrix] = gameData.numberToDisplayDictionary[_LevelMatrix] - 1;
        }
    }
    public void SaveGameNow()
    {
        SaveSysteam.SaveGame(this);
    }       
    public void GetvalueFromGameData()
    {
        GameData data = SaveSysteam.LoadGame();

        if (data == null ||
            data.bestScoreNumberDictionary == null ||
            !data.bestScoreNumberDictionary.ContainsKey(7))
        {
            FindObjectOfType<MainMenuPanelManager>().OpenInfoPanel();
            return;
        }
        gameData = data;        
    }
}
