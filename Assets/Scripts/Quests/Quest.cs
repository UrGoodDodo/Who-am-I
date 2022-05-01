using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quest
{
    public int questID;

    public bool IsActive;

    public string title;
    //public string description;

    public string[] termsText;
    //public bool[] terms;
    
    public int numericGoal;

    public void Complete() 
    {
        IsActive = false;
        Debug.Log(title + "выполненно");
    }
}
