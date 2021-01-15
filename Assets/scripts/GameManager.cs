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
        Application.runInBackground = true;
        number = 1;
        fakeLevelNumber= 1;
    }

    private void Update()
    {
        if (!Application.runInBackground)
        {
            Application.runInBackground = true;
        }
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
