using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveSerial : MonoBehaviour
{
    public GameObject dm;
    int sceneIndex;

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
        SaveData data = new SaveData();
        data.finishedDialogs = dm.GetComponent<DialogueManager>().finishedDialogs;
        data.finishedFlags = dm.GetComponent<DialogueManager>().finishedFlags;
        data.sceneIndex = sceneIndex = SceneManager.GetActiveScene().buildIndex;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }
     

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            dm.GetComponent<DialogueManager>().finishedDialogs = data.finishedDialogs;
            dm.GetComponent<DialogueManager>().finishedFlags = data.finishedFlags;
            sceneIndex = data.sceneIndex;
            SceneManager.LoadScene(sceneIndex);
            Debug.Log("Game data loaded!");
            Debug.Log(Application.persistentDataPath + "/save.dat");
        }
        else
        {
            Debug.LogError("There is no save data!");
            SceneManager.LoadScene(1);            
        }        
    }
}

[Serializable]
class SaveData
{
    public bool[] finishedDialogs;
    public bool[] finishedFlags;
    public int sceneIndex;
}