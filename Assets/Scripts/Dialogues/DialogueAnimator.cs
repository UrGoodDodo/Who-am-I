using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;
    public Player player;

    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (collision.tag == "Player")
        {
            if (!dm.finishedDialogs[1])
                startAnim.SetBool("startOpen", true);      
            else if (!dm.finishedDialogs[6] && dm.finishedDialogs[4] && player.extraQuest.IsActive && player.extraQuest.questID == 0)
                startAnim.SetBool("startOpen", true);
            else if (player.mainQuest.IsActive && player.mainQuest.questID == 2)
                startAnim.SetBool("startOpen", true);
            else if (player.mainQuest.IsActive && player.mainQuest.questID == 5)
                startAnim.SetBool("startOpen", true);
            else if (player.mainQuest.IsActive && player.mainQuest.questID == 6)
                startAnim.SetBool("startOpen", true);
            else if (dm.finishedDialogs[26])
                startAnim.SetBool("startOpen", true);
        }        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {        
        startAnim.SetBool("startOpen", false);
        dm.EndDialogue();
    }
}
