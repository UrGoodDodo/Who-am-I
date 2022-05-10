using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class telephone : MonoBehaviour
{
    public DialogueManager dm;
    public Choiser choiser;

    public void Phone(int id)
    {
        switch(id)
        {
            case 0:
                dm.StartDialogue(43);
                break;
            case 1:
                dm.StartDialogue(44);
                break;
            case 2:
                if (choiser.choisess.Sum() >= 0)
                    dm.StartDialogue(45);
                else
                    dm.StartDialogue(46);
                break;
            case 3:
                if (choiser.choisess.Sum() >= 0)
                    dm.StartDialogue(47);
                else
                    dm.StartDialogue(48);
                break;
        }
    }
}
