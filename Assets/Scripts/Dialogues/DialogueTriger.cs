using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{
    public DialogueManager dm;

    public void TriggerDialogue()
    {                    
        if (!dm.finishedDialogs[1])
            FindObjectOfType<DialogueManager>().StartDialogue(1);
        else if (!dm.finishedDialogs[6])
            FindObjectOfType<DialogueManager>().StartDialogue(6);
    }
}
