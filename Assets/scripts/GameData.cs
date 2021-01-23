using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public Dictionary<int, int> numberToDisplayDictionary = new Dictionary<int, int>();
   
    public Dictionary<int, int> emptyButtonAmountAtLevelEndDictionary = new Dictionary<int, int>();
    
    public Dictionary<int, int> levelNumberToDisplayDictionary = new Dictionary<int, int>();
   
    public Dictionary<int, int> bestScoreNumberDictionary = new Dictionary<int, int>();

    public Dictionary<int, int> bestScoreLevelDictionary = new Dictionary<int, int>();

    public int selectedLang = -1;

    public GameData(){}
}
