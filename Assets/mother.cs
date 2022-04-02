using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mother : MonoBehaviour
{
    public DialogueManager dm;
    public QuestGiver qg;

    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (collision.tag == "Player" && !dm.finishedDialogs[17] && dm.finishedDialogs[6])
        {
            dm.StartDialogue(17);
        }
    }
}
