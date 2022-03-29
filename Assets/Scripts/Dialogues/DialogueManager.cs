using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject questGiver;

    public Text dialogueText;	//Текст в диалоге    
    public Text playerText;
    public Image playerSprite;

    public Animator boxAnim;
    public Animator startAnim;

    public Sprite[] playerSprites;
    public TextAsset[] dialogAssets;

    private Queue<Node> sentences = new Queue<Node>();

    public GameObject player;
    public GameObject babyPlayer;
    public GameObject OutOfLobby;
    public GameObject OutOfLobby2;
    public GameObject P_TimeLine;
    public GameObject[] ChRoomACT1 = new GameObject[2];
    public GameObject[] ChRoomACT2 = new GameObject[2];

    private int dialogueID;

    public bool[] finishedDialogs;
    public bool[] finishedFlags;

    public ClassTest test;
    public Choiser choiser;
    public void Start()
    {
        finishedDialogs = new bool[dialogAssets.Length];
        finishedFlags = new bool[2];

        StartCoroutine(StartDialogWithTimer(0, 11f));
    }

    public void Update()
    {


    }

    public IEnumerator StartDialogWithTimer(int id, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartDialogue(id);
    }
    public void StartDialogue(int dialogueID)
    {
        player.GetComponent<Move>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        if (dialogueID == 2 || dialogueID == 3)
        {
            babyPlayer.GetComponent<Move>().enabled = false;
            babyPlayer.GetComponent<Animator>().enabled = false;
        }


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
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;

        if (dialogueID == 2 || dialogueID == 3)
        {
            babyPlayer.GetComponent<Move>().enabled = true;
            babyPlayer.GetComponent<Animator>().enabled = true;
        }

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
                    player.GetComponent<Move>().MoveOutLobbyToLocation(101);
                    OutOfLobby2.SetActive(true);           // Переход на локацию 2ой главы
                    foreach (var item in ChRoomACT1)
                        item.SetActive(false);
                    foreach (var item in ChRoomACT2)
                        item.SetActive(true);
                    break;
                }
            case 5:
                {
                    questGiver.GetComponent<QuestGiver>().OpenQuestWindow(0);
                    break;
                }
            case 8:
                {
                    test.ShowTest(0);
                    break;
                }
            case 10:
                {
                    choiser.ShowChoiser(0);
                    break;
                }
        }
    }
}
