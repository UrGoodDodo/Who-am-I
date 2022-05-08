using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriger : MonoBehaviour
{
    public DialogueManager dm;
    public Choiser choiser;

    public BoxCollider2D mother;
    public BoxCollider2D friend;
    public CircleCollider2D arbitr;
    public BoxCollider2D stranger;
    public BoxCollider2D forestStranger;
    public BoxCollider2D roma;
    public BoxCollider2D prepod;

    public int currentDialog;
    private void Start()
    {
        mother.enabled = false;
        friend.enabled = false;
        stranger.enabled = false;
        forestStranger.enabled = false;
        mother.enabled = false;

        arbitr.enabled = true;

        prepod.enabled = true;
        roma.enabled = false;

        currentDialog = 1;
    }

    public void TriggerDialogue()
    {        
        dm.StartDialogue(currentDialog);
    }
}
