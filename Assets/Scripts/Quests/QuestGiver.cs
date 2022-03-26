using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    // public Player player;

    public GameObject questwindow;
    public GameObject questprog;
    public Text questname;

    public void SetActiveQuestWindow() // Активация окна с квестом
    {
        questwindow.SetActive(true);
        questname.text = quest.title;
    }
}
