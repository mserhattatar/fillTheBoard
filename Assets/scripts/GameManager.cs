using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   
    [HideInInspector]
    public Dictionary<int, int> numberToDisplayDictionary = new Dictionary<int, int>();
    [HideInInspector]
    public Dictionary<int, int> emptyButtonAmountAtLevelEndDictionary = new Dictionary<int, int>();
    [HideInInspector]
    public Dictionary<int, int> levelNumberToDisplayDictionary = new Dictionary<int, int>();
    [HideInInspector]
    public Dictionary<int, int> bestScoreNumberDictionary = new Dictionary<int, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        if (numberToDisplayDictionary.Keys.Count > 0) return;
        foreach (var gameIndex in new List<int> { 7, 8, 9, 10 })
        {
            numberToDisplayDictionary.Add(gameIndex, 1);
            emptyButtonAmountAtLevelEndDictionary.Add(gameIndex, 0);
            levelNumberToDisplayDictionary.Add(gameIndex, 1);
            bestScoreNumberDictionary.Add(gameIndex, 0);
        }
    }
    public void ResetGame()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;
        numberToDisplayDictionary[_LevelMatrix] = 1;
        levelNumberToDisplayDictionary[_LevelMatrix] = 1;
        emptyButtonAmountAtLevelEndDictionary[_LevelMatrix] = 1;
        SaveGameNow();

    }
    public void LevelComplete()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;
        numberToDisplayDictionary[_LevelMatrix] = ButtonManager.instance.numberToDisplay;
        SetBestScore();
        levelNumberToDisplayDictionary[_LevelMatrix] += 1;
        ButtonManager.instance.SetEmptyButtonAmount();
        SaveGameNow();
    }
    private void SetBestScore()
    {
        int _LevelMatrix = ButtonManager.instance.LevelButtonMatrix;

        if (bestScoreNumberDictionary[_LevelMatrix] < numberToDisplayDictionary[_LevelMatrix])
        {
            bestScoreNumberDictionary[_LevelMatrix] = numberToDisplayDictionary[_LevelMatrix] - 1;
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
            data.bestScoreNumberDictionary.ContainsKey(7)) return;


        numberToDisplayDictionary = data.numberToDisplayDictionary;
        emptyButtonAmountAtLevelEndDictionary = data.emptyButtonAmountAtLevelEndDictionary;
        levelNumberToDisplayDictionary = data.levelNumberToDisplayDictionary;
        bestScoreNumberDictionary = data.bestScoreNumberDictionary;

    }
}
