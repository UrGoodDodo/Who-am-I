using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Threading;

public class DialogueManager : MonoBehaviour
{
    public GameObject questGiver;
    public DialogueTriger dt;

    public Text dialogueText;	//Текст в диалоге    
    public Text playerText;
    public Image playerSprite;
    public GameObject blackScreen;

    public Animator boxAnim;
    public Animator startAnim;

    public Sprite[] playerSprites;
    public TextAsset[] dialogAssets;

    private Queue<Node> sentences = new Queue<Node>();

    public GameObject OutOfLobby;
    public GameObject OutOfLobby2;
    public GameObject P_TimeLine;
    public Sprite phone;
    public GameObject slotimage;
    public GameObject[] ChRoomACT1 = new GameObject[2];
    public GameObject[] ChRoomACT2 = new GameObject[2];

    private int dialogueID;

    public bool[] finishedDialogs;
    public bool[] finishedFlags;

    public ClassTest test;
    public Choiser choiser;

    public GameObject stranger;
    public GameObject streetStranger;
    public GameObject mother;
    public GameObject mirror;
    public GameObject ugroza;

    [Header("Player Settings")]
    public GameObject player;
    public Sprite stay;
    public GameObject babyPlayer;
    public GameObject PlayerPigama;
    public Sprite stayPigama;
    public GameObject playerHudi;

    [Header("Change Sprites")]
    public GameObject lobby2;
    public GameObject lobby;
    public GameObject fon;
    public GameObject[] slots;
    public Sprite d_mask;

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
        playerHudi.GetComponent<Animator>().enabled = false;
        PlayerPigama.GetComponent<Animator>().enabled = false;
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
        playerHudi.GetComponent<Animator>().enabled = true;
        PlayerPigama.GetComponent<Animator>().enabled = true;
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
                    dt.currentDialog = 6;
                    dt.arbitr.enabled = false;
                    dt.mother.enabled = true;
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
                    ChRoomACT2[3].GetComponent<Slot>().itemid = 1;
                    slotimage.SetActive(true);
                    slotimage.GetComponent<Image>().sprite = phone;

                    player.GetComponent<Animator>().enabled = false;
                    player.GetComponent<SpriteRenderer>().enabled = false;

                    PlayerPigama.SetActive(true);
                    player.GetComponent<Move>().player = PlayerPigama;
                    player.GetComponent<Move>().stay = stayPigama;
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
            case 11:
                {
                    blackScreen.SetActive(true);
                    StartCoroutine(StartDialogWithTimer(13, 0.5f));
                    break;
                }
            case 12:
                {
                    questGiver.GetComponent<QuestGiver>().FixColor();
                    questGiver.GetComponent<QuestGiver>().OpenQuestWindow(5);
                    break;
                }
            case 13:
                {
                    blackScreen.SetActive(false);
                    player.GetComponent<Move>().MoveOutLobbyToLocation(131);
                    questGiver.GetComponent<QuestGiver>().FixColor();
                    questGiver.GetComponent<QuestGiver>().OpenQuestWindow(1);
                    stranger.SetActive(false);
                    break;
                }
            case 15:
                {
                    questGiver.GetComponent<QuestGiver>().CloseQuestWindow(2);
                    test.ShowTest(2);
                    break;
                }
            case 16:
                {
                    questGiver.GetComponent<QuestGiver>().OpenQuestWindow(3);
                    dt.currentDialog = 17;
                    dt.friend.enabled = false;
                    dt.mother.enabled = true;
                    break;
                }
            case 17:
                {
                    questGiver.GetComponent<QuestGiver>().OpenQuestWindow(4);
                    questGiver.GetComponent<QuestGiver>().OpenExtraQuestWindow(1);
                    break;
                }
            case 18:
                {
                    choiser.ShowChoiser(1);
                    break;
                }
            case 19:
                {
                    blackScreen.SetActive(true);
                    StartCoroutine(StartDialogWithTimer(13, 0.5f));
                    dt.currentDialog = 15;
                    dt.friend.enabled = true;
                    dt.stranger.enabled = false;
                    break;
                }
            case 20:
                {
                    questGiver.GetComponent<QuestGiver>().OpenQuestWindow(6);
                    streetStranger.SetActive(true);
                    stranger.SetActive(false);
                    dt.currentDialog = 21;
                    dt.stranger.enabled = false;
                    dt.forestStranger.enabled = true;
                    break;
                }
            case 21:
                {
                    questGiver.GetComponent<QuestGiver>().CloseQuestWindow(6);
                    blackScreen.SetActive(true);
                    StartCoroutine(StartDialogWithTimer(22, 0.5f));
                    break;
                }
            case 22:
                {
                    blackScreen.SetActive(false);
                    streetStranger.SetActive(false);
                    questGiver.GetComponent<QuestGiver>().OpenExtraQuestWindow(1);
                    player.GetComponent<Move>().MoveOutLobbyToLocation(112);
                    mother.SetActive(false);
                    break;
                }
            case 23:
            case 24:
            case 25:
                {
                    lobby.SetActive(false);
                    lobby2.SetActive(true);
                    foreach (var item in slots)
                    {
                        item.GetComponent<Image>().sprite = d_mask;
                        item.GetComponent<Slot>().itemid = 0;
                    }
                    slotimage.GetComponent<Image>().sprite = d_mask;
                    player.GetComponent<Move>().MoveOutLobbyToLocation(-112);
                    player.GetComponent<Move>().stay = stay;
                    player.GetComponent<Move>().player = player;
                    player.GetComponent<Animator>().enabled = true;
                    player.GetComponent<SpriteRenderer>().enabled = true;
                    PlayerPigama.SetActive(false);
                    playerHudi.SetActive(false);
                    StartCoroutine(StartDialogWithTimer(26, 0.5f));

                    dt.mother.enabled = false;
                    dt.arbitr.enabled = true;

                    if (dialogueID == 23 || dialogueID == 24)
                        dt.currentDialog = 27;
                    else dt.currentDialog = 28;
                    break;
                }
            case 27:
            case 28:
                {
                    fon.SetActive(true);

                    break;
                }
            case 29:
                questGiver.GetComponent<QuestGiver>().OpenQuestWindow(7);
                break;
            case 30:
                questGiver.GetComponent<QuestGiver>().OpenQuestWindow(8);
                break;
            case 31:
                dt.roma.enabled = false;
                break;
            case 33:
                if (choiser.choisess.Sum() >= 0)
                {
                    blackScreen.SetActive(false);
                    player.GetComponent<Move>().MoveOutLobbyToLocation(-112);
                    questGiver.GetComponent<QuestGiver>().CloseQuestWindow(8);
                    StartCoroutine(StartDialogWithTimer(36, 1f));
                }
                else
                {
                    questGiver.GetComponent<QuestGiver>().CloseQuestWindow(8);
                    questGiver.GetComponent<QuestGiver>().OpenQuestWindow(9);
                    dt.currentDialog = 39;
                    dt.prepod.enabled = true;
                }
                break;
            case 34:
                dt.currentDialog = 35;
                dt.arbitr.enabled = true;
                mirror.GetComponent<Button>().enabled = false;
                break;
            case 35:
                choiser.ShowChoiser(2);
                break;
            case 36:
                dt.arbitr.enabled = false;
                break;
            case 37:
            case 38:
                SceneManager.LoadScene(1);
                break;
            case 39:
                questGiver.GetComponent<QuestGiver>().CloseQuestWindow(9);
                blackScreen.SetActive(true);
                StartCoroutine(Wait());
                player.GetComponent<Move>().MoveOutLobbyToLocation(341);
                dt.prepod.enabled = false;
                questGiver.GetComponent<QuestGiver>().OpenQuestWindow(10);
                ugroza.SetActive(true);
                dt.currentDialog = 40;
                break;
            case 40:
                blackScreen.SetActive(true);
                StartCoroutine(Wait());
                StartCoroutine(StartDialogWithTimer(41, 2.5f));
                questGiver.GetComponent<QuestGiver>().CloseQuestWindow(10);
                break;
            case 41:
                player.GetComponent<Move>().MoveOutLobbyToLocation(-112);
                StartCoroutine(StartDialogWithTimer(42, 1f));
                break;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        blackScreen.SetActive(false);
    }
}
