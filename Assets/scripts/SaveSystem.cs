using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 

public static class SaveSysteam 
{

    public static void SaveGame(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/7x7Game.Data";
        FileStream stream = new FileStream(path, FileMode.Create);
        //GameData data = new GameData(gameManager);

        formatter.Serialize(stream, gameManager.gameData);
        stream.Close();
    }
    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/7x7Game.Data";
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
            Debug.LogError("save File Not Found in" + path);
            return null;
        }
    }
   
}
