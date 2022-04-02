using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    int questID;

    public Quest[] mainQuests;
    public Quest[] extraQuests;

    public Player player;

    public GameObject questWindow;
    public Text title;
    public Text[] termsText;
    //public bool[] terms;

    public GameObject extraQuestWindow;
    public Text extraTitle;
    public Text extraText;


    public void OpenQuestWindow(int questID) // Активация окна с квестом
    {
        questWindow.SetActive(true);
        player.mainQuest = mainQuests[questID];
        player.mainQuest.IsActive = true;
        title.text = mainQuests[questID].title;
        for (int i = 0; i < mainQuests[questID].termsText.Length; i++)
        {
            termsText[i].text = mainQuests[questID].termsText[i];
            //terms[i] = mainQuests[questID].terms[i];
        }
    }

    public void OpenExtraQuestWindow(int questID) // Активация окна с квестом
    {
        extraQuestWindow.SetActive(true);
        player.extraQuest = extraQuests[questID];
        player.extraQuest.IsActive = true;
        extraTitle.text = extraQuests[questID].title;
        extraText.text = extraQuests[questID].termsText[0];        
    }

    public void CloseQuestWindow(int questID) // Закрытие окна с квестом
    {
        questWindow.SetActive(false);        
        player.mainQuest.IsActive = false;        
    }

    public void CloseExtraQuestWindow(int questID) // Закрытие окна с квестом
    {
        extraQuestWindow.SetActive(false);
        player.extraQuest.IsActive = false;       
    }

    public void FixColor()
    {
        for (int i = 0; i < 3; i++)
        {
            termsText[i].text = "";
            termsText[i].color = Color.white;
        }
    }       
}
