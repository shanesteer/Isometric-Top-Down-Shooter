using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //Taken from Prof. Katerina Bourazeri's lecture 7 slides

    public static void Save(PlayerController1 playerController1)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filename = Application.persistentDataPath + "/player.dat";
        FileStream file = new FileStream(filename, FileMode.Create);

        PlayerData data = new PlayerData(playerController1);

        formatter.Serialize(file, data);
        file.Close();
    }

    public static PlayerData Load()
    {
        string filename = Application.persistentDataPath + "/player.dat";
        if (File.Exists(filename))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(filename, FileMode.Open);

            PlayerData data = formatter.Deserialize(file) as PlayerData;
            file.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + filename);
            return null;
        }
    }

    
}
