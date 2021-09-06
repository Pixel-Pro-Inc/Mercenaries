using Assets.Scripts.Entities.Character;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SerializedObjectManager
{
    //Add File Paths Here
    public string[] paths = {"mercenaries/CharacterData/", "mercenaries/PurchasesData" }; // Add name to find specific character 

    public void SaveData(object serializedData, string path)
    {
        string savePath = Application.persistentDataPath + path;

        var save = serializedData;

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
    }
    public object RetrieveData(string path)
    {
        string savePath = Application.persistentDataPath + path;
        Object load = null;

        if (File.Exists(savePath))
        {            
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                load = (Object)binaryFormatter.Deserialize(fileStream);
            }
        }

        return load;
    }
}
