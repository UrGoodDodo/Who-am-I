using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    bool isSlept;

    public GameObject bedBtn;
    public GameObject blackScreen;
    public QuestGiver qg;

    public ClassTest test;
    public DialogueManager dm;
    public Choiser choiser;

    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (!isSlept && qg.player.extraQuest.questID == 1)
        {
            bedBtn.SetActive(true);            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        bedBtn.SetActive(false);
    }

    public void DoSleep()
    {       
        isSlept = true;
        StartCoroutine(Sleep());
        qg.CloseExtraQuestWindow(1);
        qg.CloseQuestWindow(4);
        bedBtn.SetActive(false);

        if (choiser.choisess[0] == 1 || choiser.choisess[1] == 1)
            if (test.rightAnswers >= 10)
                StartCoroutine(dm.StartDialogWithTimer(23,2f));
            else
                StartCoroutine(dm.StartDialogWithTimer(24, 2f));
        else
            StartCoroutine(dm.StartDialogWithTimer(25, 2f));
    }

    IEnumerator Sleep()
    {     
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2f);   
        blackScreen.SetActive(false);   
    }
}
