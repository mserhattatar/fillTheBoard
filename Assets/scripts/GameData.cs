using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int number;
    public int emptyButtonCount;
    public int fakeLevelNumber;

    public GameData(GameManager gameManager)
    {
        number = gameManager.number;
        emptyButtonCount = gameManager.emptyButtonCount;
        fakeLevelNumber = gameManager.fakeLevelNumber;
}

}
