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
    public void GetvalueFromGameData()
    {
        GameData data = SaveSysteam.getSavedGameData();

        if (data == null || data.numberToDisplayDictionary == null || !data.numberToDisplayDictionary.ContainsKey(7))
        {
            InitGameDataDict(gameData.numberToDisplayDictionary, 1);
            InitGameDataDict(gameData.emptyButtonAmountAtLevelEndDictionary, 0);
            InitGameDataDict(gameData.levelNumberToDisplayDictionary, 1);
            InitGameDataDict(gameData.bestScoreNumberDictionary, 0);
            InitGameDataDict(gameData.bestScoreLevelDictionary, 0);
            gameData.selectedLang = (int)LangNamespace.Language.English;

            FindObjectOfType<MainMenuPanelManager>().InfoPanelButtonAni();
        }
        else
        {
            gameData = data;
        }

        LanguageManager.instance.initLayoutManager();
    }
    private void InitGameDataDict(Dictionary<int, int> gameDataDict, int firstValue)
    {
        foreach (var gameIndex in new List<int> { 7, 8, 9, 10 })
        {
            gameDataDict.Add(gameIndex, firstValue);
        }
    }
    public void SaveGameNow()
    {
        SaveSysteam.SaveGameData(this);
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
    public void SaveBestScore()
    {
        SetBestScore();
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
    public void ResetGame()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;
        gameData.numberToDisplayDictionary[_LevelMatrix] = 1;
        gameData.levelNumberToDisplayDictionary[_LevelMatrix] = 1;
        gameData.emptyButtonAmountAtLevelEndDictionary[_LevelMatrix] = 0;
        SaveGameNow();

    }

    //Hile
    public void ResetGameDataDict()
    {
        foreach (var gameIndex in new List<int> { 7, 8, 9, 10 })
        {
            gameData.numberToDisplayDictionary[gameIndex] = 1;
            gameData.emptyButtonAmountAtLevelEndDictionary[gameIndex] = 0;
            gameData.levelNumberToDisplayDictionary[gameIndex] = 1;
            gameData.bestScoreNumberDictionary[gameIndex] = 0;
            gameData.bestScoreLevelDictionary[gameIndex] = 0;
        }
    }
    public void SerhatHile(int matrix, int number)
    {
        gameData.numberToDisplayDictionary[matrix] = number;
    }
}
