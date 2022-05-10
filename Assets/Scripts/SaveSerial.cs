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
    public DialogueTriger dt;
    public kurtki kurtki;

    public bool isLoaded = false;

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.dat");
        SaveData data = new SaveData();
        data.finishedDialogs = dm.GetComponent<DialogueManager>().finishedDialogs;
        data.finishedFlags = dm.GetComponent<DialogueManager>().finishedFlags;
        data.x = player.GetComponent<Transform>().position.x;
        data.y = player.GetComponent<Transform>().position.y;
        data.z = player.GetComponent<Transform>().position.z;
        data.camX = cam.GetComponent<Transform>().position.x;
        data.camY = cam.GetComponent<Transform>().position.y;
        data.camZ = cam.GetComponent<Transform>().position.z;

        data.minX = cam.GetComponent<MoveCamera>().minX;
        data.maxX = cam.GetComponent<MoveCamera>().maxX;
        data.minY = cam.GetComponent<MoveCamera>().minY;
        data.maxY = cam.GetComponent<MoveCamera>().maxY;

        data.mainQst = player.GetComponent<Player>().mainQuest;
        data.extraQst = player.GetComponent<Player>().extraQuest;
        data.choises = choiser.choisess;
        data.isWeared = shkaf.isWeared;
        data.finishedTest = tests.finishedTest;
        data.rightAnswers = tests.rightAnswers;
        data.isShowed = tips.IsTipsShowed;
        data.isBlocked = tips.IsTipsBlocked;

        data.mother = dt.mother.enabled;
        data.friend = dt.friend.enabled;
        data.stranger = dt.stranger.enabled;
        data.forestStranger = dt.forestStranger.enabled;
        data.arbitr = dt.arbitr.enabled;
        data.prepod = dt.prepod.enabled;
        data.roma = dt.roma.enabled;
        data.ugroza = dm.GetComponent<DialogueManager>().ugroza.activeSelf;
        data.currentDialog = dt.currentDialog;

        data.tips = tips.gameObject.activeSelf;
        data.isChecked = kurtki.isCheked;

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
            player.GetComponent<Transform>().position = new Vector3(data.x, data.y, data.z);
            cam.GetComponent<Transform>().position = new Vector3(data.camX, data.camY, data.camZ);

            tips.gameObject.SetActive(data.tips);
            kurtki.isCheked = data.isChecked;

            cam.GetComponent<MoveCamera>().minX = data.minX;
            cam.GetComponent<MoveCamera>().maxX = data.maxX;
            cam.GetComponent<MoveCamera>().minY = data.minY;
            cam.GetComponent<MoveCamera>().maxY = data.maxY;

            choiser.choisess = data.choises;
            shkaf.isWeared = data.isWeared;
            tests.finishedTest = data.finishedTest;
            tests.rightAnswers = data.rightAnswers;
            tips.IsTipsShowed = data.isShowed;
            tips.IsTipsBlocked = data.isBlocked;

            dt.mother.enabled = data.mother;
            dt.friend.enabled = data.friend;
            dt.stranger.enabled = data.stranger;
            dt.forestStranger.enabled = data.forestStranger;
            dt.arbitr.enabled = data.arbitr;
            dt.prepod.enabled = data.prepod;
            dt.roma.enabled = data.roma;
            dm.GetComponent<DialogueManager>().ugroza.SetActive(data.ugroza);
            dt.currentDialog = data.currentDialog;
                 
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
    public float z;
    public float camX;
    public float camY;
    public float camZ;
    public Quest mainQst;
    public Quest extraQst;
    public int[] choises;
    public bool isWeared;
    public bool[] finishedTest;
    public int rightAnswers;
    public bool[] isShowed;
    public bool[] isBlocked;
    public int currentDialog;
    public bool mother;
    public bool friend;
    public bool stranger;
    public bool forestStranger; 
    public bool arbitr;
    public bool prepod;
    public bool roma;
    public bool ugroza;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public bool tips;
    public bool isChecked;
}