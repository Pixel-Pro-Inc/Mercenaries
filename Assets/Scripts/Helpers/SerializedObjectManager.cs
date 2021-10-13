using Assets.Scripts.Entities.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;

public class SerializedObjectManager
{
    //Add File Paths Here
    public string[] paths = {"/CharacterData/", "/PurchasesData", "/DefaultValues/" }; // Add name to find specific character 

    public void SaveData(object serializedData, string path)
    {
        string pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path + ".txt");

        if (File.Exists(pathFile))
            File.Delete(pathFile);

        XmlSerializer serializer1 = new XmlSerializer(typeof(object));//initialises the serialiser

        Stream writer = new FileStream(pathFile, FileMode.Create);//initialises the writer
        serializer1.Serialize(writer, serializedData);//Writes to the file
        writer.Close();//Closes the writer

        /*string savePath = Path.Combine(Application.persistentDataPath, path);

        var save = serializedData;

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }*/
    }
    public object RetrieveData(string path)
    {
        string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path + ".txt");

        if (File.Exists(filepath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(object));//initialises the serialiser
            FileStream reader = new FileStream(filepath, FileMode.Open); //Initialises the reader
            object x;

            x = (object)serializer.Deserialize(reader); //reads from the xml file and inserts it in this variable
            reader.Close(); //closes the reader
            return x;
        }

        return null;
        

        /*
        string savePath = Application.persistentDataPath + path;
        Object load = null;

        if (File.Exists(savePath))
        {            
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                load = (Object)binaryFormatter.Deserialize(fileStream);
            }
        }*/
    }
}
