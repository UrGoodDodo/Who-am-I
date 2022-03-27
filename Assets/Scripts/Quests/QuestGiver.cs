using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    int questID;

    public Quest[] mainQuests;
    public Quest[] additionalQuests;

    public Player player;

    public GameObject questWindow;
    public Text title;
    public Text[] termsText;
    //public bool[] terms;


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

    public void CloseQuestWindow(int questID) // Закрытие окна с квестом
    {
        questWindow.SetActive(false);        
        player.mainQuest.IsActive = false;        
    }
}
