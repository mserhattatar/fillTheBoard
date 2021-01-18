using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int numberToDisplay;
    public int emptyButtonCount;
    public int levelNumberToDisplay;
    public int bestCoreNumber;

    public GameData(GameManager gameManager)
    {
        numberToDisplay = gameManager.numberToDisplay;
        emptyButtonCount = gameManager.emptyButtonAmountAtLevelEnd;
        levelNumberToDisplay = gameManager.levelNumberToDisplay;
        bestCoreNumber = gameManager.bestScoreNumber;
    }
}
