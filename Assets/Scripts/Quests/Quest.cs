using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool IsActive;

    public string title;
    //public 

    public QuestGoal goal;

    public void Complete() 
    {
        IsActive = false;
        Debug.Log(title + "выполненно");
    }

}
