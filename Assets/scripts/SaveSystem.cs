using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 

public static class SaveSysteam 
{
    // Saves the gameData object to the stream (for info like best score, level number ...)
    public static void SaveGameData(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/7x73game.Data";
        FileStream stream = new FileStream(path, FileMode.Create);
        //GameData data = new GameData(gameManager);

        formatter.Serialize(stream, gameManager.gameData);
        stream.Close();
    }
    
    public static GameData getSavedGameData()
    {
        
        string path = Application.persistentDataPath + "/7x73game.Data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("save File Not Found in" + path);
            return null;
        }
    }
   
}
