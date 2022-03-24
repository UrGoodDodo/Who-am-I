using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject save;
    public GameObject tip;

    public Text dialogueText;	//Текст в диалоге    
    public Text playerText;
    public Image playerSprite;

    public Animator boxAnim;
    public Animator startAnim;

    public Sprite[] playerSprites;
    public TextAsset[] dialogAssets;

    private Queue<Node> sentences = new Queue<Node>();

    public GameObject player;
    public GameObject OutOfLobby;
    public GameObject P_TimeLine;

    private int dialogueID;

    public bool[] finishedDialogs;
    public bool[] finishedFlags;

    public void Start()
    {
        finishedDialogs = new bool[] { false, false, false, false,false };
        finishedFlags = new bool[] { false,false };

        StartCoroutine(StartDialogWithTimer(0, 11f));
    }

    public void Update()
    {        

       /* if (SceneManager.GetActiveScene().buildIndex == 2 && !finishedDialogs[2])
        {
            StartDialogue(2);
            finishedDialogs[2] = true;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && finishedFlags[0])
            StartDialogWithTimer(4, 1f);        */
    }

    public IEnumerator StartDialogWithTimer(int id, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartDialogue(id);
    }
    public void StartDialogue(int dialogueID)
    {
        player.GetComponent<Move>().enabled = false;

        this.dialogueID = dialogueID;

        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen", false);

        Dialogue dialogue = Dialogue.Load(dialogAssets[dialogueID]);

        sentences.Clear();

        foreach (Node sentence in dialogue.nodes)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        Node nod = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(nod.npctext));
        playerText.text = nod.npcname;
        playerSprite.sprite = playerSprites[nod.npclogo];
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        player.GetComponent<Move>().enabled = true;
        boxAnim.SetBool("boxOpen", false);
        finishedDialogs[dialogueID] = true;
        switch (dialogueID)
        {            
            case 1:
                {     
                    P_TimeLine.SetActive(true);
                    //player.GetComponent<Move>().MoveOutLobbyToLocation(0); 
                    //OutOfLobby.SetActive(true);                   
                    break;
                }            
            case 4:
                {
                    player.GetComponent<Move>().MoveOutLobbyToLocation(0);
                    OutOfLobby.SetActive(true);                    
                    break;
                }
        }        
    }
}
