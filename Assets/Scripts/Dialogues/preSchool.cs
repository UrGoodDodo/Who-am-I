using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preSchool : MonoBehaviour
{
    public GameObject dm;
    
    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (collision.tag == "Player" && !dm.GetComponent<DialogueManager>().finishedDialogs[7])
        {
            dm.GetComponent<DialogueManager>().StartDialogue(7);
        }
    }
}
