using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;


    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {        
        startAnim.SetBool("startOpen", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {        
        startAnim.SetBool("startOpen", false);
        dm.EndDialogue();
    }
}
