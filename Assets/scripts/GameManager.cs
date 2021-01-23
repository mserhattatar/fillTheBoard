using UnityEngine;
using System.Collections.Generic;
using LangNamespace;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData gameData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameData = new GameData();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }       
        GetvalueFromGameData();
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
        gameData.emptyButtonAmountAtLevelEndDictionary[_LevelMatrix] = GameObject.FindGameObjectsWithTag("empty").Length;
        gameData.selectedLang = LanguageManager.instance.selectedLang;
        SaveGameNow();
    }   
    public void SaveSelectedLanguage()
    {
        gameData.selectedLang = LanguageManager.instance.selectedLang;
        SaveGameNow();
    }
    private void SetBestScore()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;

        if (gameData.bestScoreNumberDictionary[_LevelMatrix] < gameData.numberToDisplayDictionary[_LevelMatrix])
        {
            gameData.bestScoreNumberDictionary[_LevelMatrix] = gameData.numberToDisplayDictionary[_LevelMatrix] - 1;
            gameData.bestScoreLevelDictionary[_LevelMatrix] = gameData.levelNumberToDisplayDictionary[_LevelMatrix];
        }
    }
    public void SaveGameNow()
    {
        SaveSysteam.SaveGameData(this);
    }   

    public void GetvalueFromGameData()
    {
        GameData data = SaveSysteam.getSavedGameData();

        gameData.numberToDisplayDictionary = InitGameDataDict(data, data.numberToDisplayDictionary, gameData.numberToDisplayDictionary, 1);
        gameData.emptyButtonAmountAtLevelEndDictionary = InitGameDataDict(data, data.emptyButtonAmountAtLevelEndDictionary, gameData.emptyButtonAmountAtLevelEndDictionary, 0);
        gameData.levelNumberToDisplayDictionary = InitGameDataDict(data, data.levelNumberToDisplayDictionary, gameData.levelNumberToDisplayDictionary, 1);
        gameData.bestScoreNumberDictionary = InitGameDataDict(data, data.bestScoreNumberDictionary, gameData.bestScoreNumberDictionary, 0);
        gameData.bestScoreLevelDictionary = InitGameDataDict(data, data.bestScoreLevelDictionary, gameData.bestScoreLevelDictionary, 0);
        
        
        if (data == null || (data !=null && data.selectedLang < 0)) //TODO 0 yerine null
        {
            gameData.selectedLang = (int)LangNamespace.Language.English;
            FindObjectOfType<MainMenuPanelManager>().InfoPanelButtonAni();
            return;
        }
        else
            gameData.selectedLang = data.selectedLang;
        
        LanguageManager.instance.initLayoutManager();
    }
    
    private Dictionary<int, int> InitGameDataDict(GameData data, Dictionary<int, int> dataDict, Dictionary<int, int> gameDataDict, int firstValue)
    { 
        if (data == null || dataDict == null || !dataDict.ContainsKey(7))
        {
            foreach (var gameIndex in new List<int> { 7, 8, 9, 10 })
            {
                gameDataDict.Add(gameIndex, firstValue);
            }
            return gameDataDict; 
        }
        gameDataDict = dataDict;
        return gameDataDict;
    }

    public void SerhatHile(int matrix, int number)
    {
        gameData.numberToDisplayDictionary[matrix] = number;
    }
}
