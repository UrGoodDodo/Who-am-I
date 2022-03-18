using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{    
    public void TriggerDialogue()
    {                    
        FindObjectOfType<DialogueManager>().StartDialogue(1);
    }
}
