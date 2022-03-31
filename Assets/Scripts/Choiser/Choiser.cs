using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choiser : MonoBehaviour
{
    public int[] choisess = new int[2]{0,0};

    public TextAsset[] choises;

    public Text btn1Text;
    public Text btn2Text;

    int choiseID;

    public GameObject choiserWindow;

    public GameObject dm;
    public GameObject player;
    public GameObject stranger;
    public void ShowChoiser(int choiseID)
    {        
        choiserWindow.SetActive(true);

        this.choiseID = choiseID;
        var parse = choises[choiseID].text.Split('/');

        btn1Text.text = parse[0];
        btn2Text.text = parse[1];
    }

    public void CloseChoiser()
    {
        choiserWindow.SetActive(false);
    }

    public void DoAction(int choise)
    {
        switch (choiseID)
        {
            case 0:
                {
                    if (choise == -1)
                    {
                        dm.GetComponent<DialogueManager>().StartDialogue(12);
                        choisess[choiseID] = choise;
                        stranger.SetActive(true);
                    }
                    else
                    {
                        dm.GetComponent<DialogueManager>().StartDialogue(11);
                        choisess[choiseID] = choise;
                    }
                    CloseChoiser();
                    break;
                }
            case 1:
                {
                    if (choise == -1)
                    {
                        dm.GetComponent<DialogueManager>().StartDialogue(20);
                        choisess[choiseID] = choise;
                    }
                    else
                    {
                        dm.GetComponent<DialogueManager>().StartDialogue(19);
                        choisess[choiseID] = choise;                        
                    }
                    CloseChoiser();
                    break;
                }
        }
    }
}
