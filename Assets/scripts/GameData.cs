using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int number;
    public int emptyButtonCount;
    public int fakeLevelNumber;
    public int bestCoreNumber;

    public GameData(GameManager gameManager)
    {
        number = gameManager.number;
        emptyButtonCount = gameManager.emptyButtonAmountAtLevelEnd;
        fakeLevelNumber = gameManager.fakeLevelNumber;
        bestCoreNumber = gameManager.bestScoreNumber;
}

}
