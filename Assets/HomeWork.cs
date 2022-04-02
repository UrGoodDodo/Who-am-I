using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    bool isTeached;

    public GameObject hwBtn;
    public GameObject blackScreen;
    public QuestGiver qg;

    public void OnTriggerEnter2D(Collider2D collision)	//���������� ��� ������������ ������� ���������� �� �������
    {
        if (!isTeached && qg.player.mainQuest.questID == 4)
        {
            hwBtn.SetActive(true);            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        hwBtn.SetActive(false);
    }

    public void DoHW()
    {        
        isTeached = true;
        StartCoroutine(HW());
        qg.CloseQuestWindow(4);
        hwBtn.SetActive(false);        
    }

    IEnumerator HW()
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        blackScreen.SetActive(false);
    }
}
