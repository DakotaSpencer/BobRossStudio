using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveWorld : MonoBehaviour
{
    void SaveGame()
    {
        object[] obj = GameObject.FindSceneObjectsOfType(typeof(GameObject));
        SaveData data = new SaveData();
        foreach (object o in obj)
        {
            string result = "";
            GameObject g = (GameObject)o;
            result += g.name + "$$";
            result += g.transform + "$$";

            data.objects.Add(result);
        }

        System.Random rand = new System.Random();
        string saveName = "HelpMe" + rand.Next(3000);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveName + ".dat");
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game saved.");
    }

    void LoadGame()
    {
        string saveName = ""; // test code or whatever will go here. then what the user actually wants
        if (File.Exists(Application.persistentDataPath + "/" + saveName + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveName + ".dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            SetWorld(data);
        }
    }

    void SetWorld(SaveData saveData)
    {
        // this method will load saved data into the world.
        foreach (string obj in saveData.objects) {
            string[] objBroken = obj.Split("$$"); // 0: name, 1: transform
            GameObject g = new GameObject(objBroken[0]);
            // do some other stuff probably besides just this...
        }
    }
}

[Serializable]
class SaveData
{
    public List<string> objects;
}