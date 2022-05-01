using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveSerial : MonoBehaviour
{

    public GameObject player;
    public GameObject dm;
    public QuestGiver qg;
    public GameObject cutscene;
    public Choiser choiser;
    public ClassTest tests;
    public shkaf shkaf;
    public Tooltips tips;
    public GameObject cam;

    public bool isLoaded = false;

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
        SaveData data = new SaveData();
        data.finishedDialogs = dm.GetComponent<DialogueManager>().finishedDialogs;
        data.finishedFlags = dm.GetComponent<DialogueManager>().finishedFlags;
        data.x = player.transform.position.x;
        data.y = player.transform.position.y;
        data.cam = cam.transform.position.x;       
        data.mainQst = player.GetComponent<Player>().mainQuest;
        data.extraQst = player.GetComponent<Player>().extraQuest;
        data.choises = choiser.choisess;
        data.isWeared = shkaf.isWeared;
        data.finishedTest = tests.finishedTest;
        data.rightAnswers = tests.rightAnswers;
        data.isShowed = tips.IsTipsShowed;
        data.isBlocked = tips.IsTipsBlocked;
        
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
        cutscene.SetActive(false);
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
            player.GetComponent<Player>().mainQuest = data.mainQst;
            player.GetComponent<Player>().extraQuest = data.extraQst;
            if (data.mainQst.IsActive)
                qg.OpenQuestWindow(data.mainQst.questID);
            if (data.extraQst.IsActive)
                qg.OpenQuestWindow(data.extraQst.questID);
            player.transform.position = new Vector3(data.x, data.y, 1);
            cam.transform.position = new Vector3(data.cam,0,-10);
            choiser.choisess = data.choises;
            shkaf.isWeared = data.isWeared;
            tests.finishedTest = data.finishedTest;
            tests.rightAnswers = data.rightAnswers;
            tips.IsTipsShowed = data.isShowed;
            tips.IsTipsBlocked = data.isBlocked;
            Debug.Log("Game data loaded!");
            Debug.Log(Application.persistentDataPath + "/save.dat");
        }        
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }
}
    
[Serializable]
class SaveData
{
    public bool[] finishedDialogs;
    public bool[] finishedFlags;
    public float x;
    public float y;
    public float cam;    
    public Quest mainQst;
    public Quest extraQst;
    public int[] choises;
    public bool isWeared;
    public bool[] finishedTest;
    public int rightAnswers;
    public bool[] isShowed;
    public bool[] isBlocked;
}