using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int number;
    public int emptyButtonCount;    
    public int fakeLevelNumber;
    
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
        number = 1;
        fakeLevelNumber= 1;
    }

    public void SetNumber()
    {
        number = ButtonManager.instance.number;
        MinNumberForNextLevel();
    }

    private void MinNumberForNextLevel()
    {
      
        fakeLevelNumber += 1;
    }
}
