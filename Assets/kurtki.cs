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

    public GameObject[] rukzak = new GameObject[3];
    public Sprite rukzakSprite;
    public Sprite studak;

    public bool isCheked = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && !isCheked && textPanel.active)
        {
            isCheked = true;
            textPanel.SetActive(false);
            panel.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (!isCheked && collision.tag == "Player")
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
    }

    public void FinishKurtki1()
    {
        isCheked = true;
        textPanel.SetActive(false);
        dm.StartDialogue(50);
        rukzak[0].SetActive(false);
        rukzak[1].GetComponent<Image>().sprite = rukzakSprite;
        rukzak[1].GetComponent<Slot>().itemid = 0;
        rukzak[2].GetComponent<Image>().sprite = studak;
        rukzak[3].SetActive(true);
        panel.SetActive(false);
        qg.CloseQuestWindow(7);
        FindObjectOfType<DialogueTriger>().roma.enabled = true;
        qg.FixColor();
        qg.OpenQuestWindow(8);
    }
}
