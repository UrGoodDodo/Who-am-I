using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{
    public DialogueManager dm;
    public Choiser choiser;

    public void TriggerDialogue()
    {
        if (!dm.finishedDialogs[1])
            dm.StartDialogue(1);
        else if (!dm.finishedDialogs[6])
            dm.StartDialogue(6);
        else if (!dm.finishedDialogs[18] && choiser.choisess[0] == -1)
            dm.StartDialogue(18);
        else if (!dm.finishedDialogs[15] && choiser.choisess[1] > -1)
            dm.StartDialogue(15);       
        else if (dm.finishedDialogs[26])
            if (choiser.choisess[0] == 1 || choiser.choisess[1] == 1)
                dm.StartDialogue(27);
            else dm.StartDialogue(28); 
        else if (!dm.finishedDialogs[21])
            dm.StartDialogue(21);
    }
}
