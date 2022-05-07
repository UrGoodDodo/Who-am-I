using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kurtki : MonoBehaviour
{    
    public GameObject textPanel;
    public GameObject panel;
    public DialogueManager dm;
    public Text wear;
    public QuestGiver qg;

    public bool isCheked = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && !isCheked)
        {
            isCheked = true;
            textPanel.SetActive(false);
            panel.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (!isCheked)
            textPanel.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        textPanel.SetActive(false);
    }

    public void FinishKurtki()
    {
        wear.color = new Color(128 / 255.0f, 128 / 255.0f, 128 / 255.0f);
        dm.StartDialogue(32);
        panel.SetActive(false);
        qg.CloseQuestWindow(7);
        FindObjectOfType<DialogueTriger>().roma.enabled = true;
    }
}
