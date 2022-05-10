using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed = 0.03f; //Скорость движения
    public Sprite stay; //Отображение стоящего персонажа
    private float side; //Определяет сторону, в которую смотрит игрок
    public GameObject player;
    public GameObject[] slot = new GameObject[2];
    public GameObject[] newSlot = new GameObject[2];
    public GameObject[] Phone = new GameObject[2];

    public GameObject Student;
    public Sprite stayStudent;

    public GameObject dm;
    public QuestGiver qg;
    public ClassTest ct;
    public Choiser choiser;
    public GameObject blackscreen;
    public GameObject mirror;
    public DialogueTriger dt;
    public GameObject tips;
    public GameObject roma;

    [Header("ACT3")]
    public GameObject[] Slots = new GameObject[3];
    public GameObject[] OffObject = new GameObject[3];
    public GameObject[] OnObjects = new GameObject[3];
    public Sprite[] SlotSprites = new Sprite[2];
    public GameObject trashbak;

    public CircleCollider2D kurtki;
    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal") * Time.deltaTime;  //Движение влево/вправо на стандартные клавиши
        transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical") * Time.deltaTime;    //Движение вверх/вниз на стандартные клавиши
        side = Input.GetAxis("Horizontal"); //Определяет, в какую сторону последней смотрел игрок при движении

        if (side < 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (side > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            player.GetComponent<Animator>().enabled = true;   //Включает анимацию при движении
            GetComponent<AudioSource>().playOnAwake = true;
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<SpriteRenderer>().sprite = stay;
            GetComponent<AudioSource>().enabled = false;
        }
    }
    public GameObject camera;
    public void MoveOutLobbyToLocation(int index)
    {
        //Первая цифра - номер главы, вторая цифра - номер комнаты, третья цифра: если 1, то левая сторона, если 2, то правая.
        switch (index)
        {
            case -111:  //Лобби слева
                GetComponent<Transform>().position = new Vector3(-9, -1, 3.5f);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = 0;
                camera.GetComponent<MoveCamera>().maxY = 0;
                break;
            case -112: //Лобби справа
                GetComponent<Transform>().position = new Vector3(4.5f, -1, 3.5f);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = 0;
                camera.GetComponent<MoveCamera>().maxY = 0;
                if (dm.GetComponent<DialogueManager>().finishedDialogs[29] || dm.GetComponent<DialogueManager>().finishedDialogs[30])
                {
                    dt.arbitr.enabled = false;
                    mirror.SetActive(true);
                }
                break;

            case 101: //Детская слева
                GetComponent<Transform>().position = new Vector3(-10, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(0, -100, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                if (!dm.GetComponent<DialogueManager>().finishedDialogs[2])
                    StartCoroutine(StartDialogWithTimer(2, 2f));
                else if (!dm.GetComponent<DialogueManager>().finishedDialogs[5])
                    StartCoroutine(StartDialogWithTimer(5, 1f));
                break;
            case 102: //Детская справа
                GetComponent<Transform>().position = new Vector3(11, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(0, -100, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                break;

            case 111: //Зал слева
                GetComponent<Transform>().position = new Vector3(180, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(185, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 185.7f;
                camera.GetComponent<MoveCamera>().maxX = 197.9f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                if (!dm.GetComponent<DialogueManager>().finishedDialogs[3])
                    StartCoroutine(StartDialogWithTimer(3, 1f));
                break;
            case 112://Зал справа
                GetComponent<Transform>().position = new Vector3(205, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(185, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 185.7f;
                camera.GetComponent<MoveCamera>().maxX = 197.9f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                if (qg.player.mainQuest.IsActive && qg.player.mainQuest.questID == 3)
                    qg.CloseQuestWindow(3);
                break;
            case 121://Улица слева
                if (qg.player.mainQuest.IsActive && qg.player.mainQuest.questID == 0 && (qg.player.mainQuest.numericGoal != 2 || qg.player.extraQuest.numericGoal != 1))
                    break;
                if (!dm.GetComponent<DialogueManager>().finishedDialogs[6])
                    dm.GetComponent<DialogueManager>().finishedDialogs[6] = true;

                GetComponent<Transform>().position = new Vector3(386, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(393, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 392.9f;
                camera.GetComponent<MoveCamera>().maxX = 407.1f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                break;
            case 122://Улица справа
                GetComponent<Transform>().position = new Vector3(413, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(393, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 392.9f;
                camera.GetComponent<MoveCamera>().maxX = 407.1f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                break;
            case 131://Коридор школы слева
                GetComponent<Transform>().position = new Vector3(-9, -208, 1);
                camera.GetComponent<Transform>().position = new Vector3(-2.106f, -206.432f, -10);
                camera.GetComponent<MoveCamera>().minX = -2.106f;
                camera.GetComponent<MoveCamera>().maxX = 0.108f;
                camera.GetComponent<MoveCamera>().minY = -206.432f;
                camera.GetComponent<MoveCamera>().maxY = -206.432f;
                if (qg.player.mainQuest.IsActive && qg.player.mainQuest.questID == 0)
                    qg.CloseQuestWindow(0);
                if (!dm.GetComponent<DialogueManager>().finishedDialogs[10])
                {
                    dt.currentDialog = 15;
                    dt.mother.enabled = false;
                    dt.friend.enabled = true;
                }
                break;
            case 132://Коридор школы справа
                GetComponent<Transform>().position = new Vector3(2, -206.5f, 1);
                camera.GetComponent<Transform>().position = new Vector3(-2.106f, -206.432f, -10);
                camera.GetComponent<MoveCamera>().minX = -2.106f;
                camera.GetComponent<MoveCamera>().maxX = 0.108f;
                camera.GetComponent<MoveCamera>().minY = -206.432f;
                camera.GetComponent<MoveCamera>().maxY = -206.432f;
                break;

            case 141://Кабинет школы слева
                GetComponent<Transform>().position = new Vector3(180, -208, 1);
                camera.GetComponent<Transform>().position = new Vector3(186.64f, -110.432f, -10);
                camera.GetComponent<MoveCamera>().minX = 186.65f;
                camera.GetComponent<MoveCamera>().maxX = 188.85f;
                camera.GetComponent<MoveCamera>().minY = -206.43f;
                camera.GetComponent<MoveCamera>().maxY = -206.43f;
                if (!dm.GetComponent<DialogueManager>().finishedDialogs[8])
                {
                    StartCoroutine(StartDialogWithTimer(8, 1f));
                    ct.finishedTest[0] = true;
                }
                else if (!ct.finishedTest[1])
                {
                    ct.ShowTest(1);
                }
                if (qg.player.mainQuest.questID == 1 && qg.player.mainQuest.IsActive)
                    qg.CloseQuestWindow(1);
                break;
            case 142://Кабинет школы справа
                GetComponent<Transform>().position = new Vector3(197, -208, 1);
                camera.GetComponent<Transform>().position = new Vector3(186.64f, -110.432f, -10);
                camera.GetComponent<MoveCamera>().minX = 186.65f;
                camera.GetComponent<MoveCamera>().maxX = 188.85f;
                camera.GetComponent<MoveCamera>().minY = -206.43f;
                camera.GetComponent<MoveCamera>().maxY = -206.43f;

                break;

            case 311://Комната в общаге слева
                slot[0].GetComponent<LighterOnOff>().enabled = false;
                slot[1].SetActive(false);
                slot[2].SetActive(false);

                newSlot[0].GetComponent<Slot>().itemid = 3;
                newSlot[1].SetActive(true);


                GetComponent<Transform>().position = new Vector3(-9.5f, -297, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -2.15f;
                camera.GetComponent<MoveCamera>().maxX = 2.1f;
                camera.GetComponent<MoveCamera>().minY = -296;
                camera.GetComponent<MoveCamera>().maxY = -296;
                tips.SetActive(false);
                if (choiser.choisess.Sum() >= 0)
                {
                    dt.currentDialog = 31;
                    StartCoroutine(StartDialogWithTimer(29, 1f));
                }
                else
                {
                    StartCoroutine(StartDialogWithTimer(30, 1f));
                    roma.SetActive(false);
                }

                GetComponent<Animator>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;

                Student.SetActive(true);
                GetComponent<Move>().player = Student;
                GetComponent<Move>().stay = stayStudent;
                break;

            case 3111://Комната в общаге слева ПЛОХАЯ                
                choiser.choisess = new int[] { -1, 0 };
                kurtki.enabled = false;
                Phone[0].SetActive(true);
                foreach (var item in OnObjects)
                {
                    item.SetActive(true);
                }
                foreach (var item in OffObject)
                {
                    item.SetActive(false);
                }
                OnObjects[0].GetComponent<Transform>().position = new Vector3(12.63f, 0, 126.4341f);
                OnObjects[0].GetComponent<Transform>().position -= new Vector3(1, 294, 0);
                Slots[0].GetComponent<Image>().sprite = SlotSprites[0];
                Slots[1].GetComponent<Image>().sprite = SlotSprites[1];
                trashbak.GetComponent<Collider2D>().enabled = false;
                MoveOutLobbyToLocation(311);
                break;

            case 3112://Комната в общаге слева ХОРОШАЯ
                choiser.choisess = new int[] { 1, 1 };
                Phone[1].SetActive(true);
                MoveOutLobbyToLocation(311);
                break;

            case 312://Комната в общаге справа
                GetComponent<Transform>().position = new Vector3(9.5f, -297, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -2.15f;
                camera.GetComponent<MoveCamera>().maxX = 2.1f;
                camera.GetComponent<MoveCamera>().minY = -296;
                camera.GetComponent<MoveCamera>().maxY = -296;
                break;
            case 321://Коридор в общаге слева
                GetComponent<Transform>().position = new Vector3(165, -297, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -297, -10);
                camera.GetComponent<MoveCamera>().minX = 172f;
                camera.GetComponent<MoveCamera>().maxX = 177.67f;
                camera.GetComponent<MoveCamera>().minY = -296;
                camera.GetComponent<MoveCamera>().maxY = -296;
                break;
            case 322://Коридор в общаге справа
                GetComponent<Transform>().position = new Vector3(185, -297, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = 172f;
                camera.GetComponent<MoveCamera>().maxX = 177.67f;
                camera.GetComponent<MoveCamera>().minY = -296;
                camera.GetComponent<MoveCamera>().maxY = -296;
                break;
            case 331://Улица
                GetComponent<Transform>().position = new Vector3(352, -297, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = 358.52f;
                camera.GetComponent<MoveCamera>().maxX = 371.73f;
                camera.GetComponent<MoveCamera>().minY = -296;
                camera.GetComponent<MoveCamera>().maxY = -296;
                break;
            case 332://Улица
                GetComponent<Transform>().position = new Vector3(379, -297, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = 358.52f;
                camera.GetComponent<MoveCamera>().maxX = 371.73f;
                camera.GetComponent<MoveCamera>().minY = -296;
                camera.GetComponent<MoveCamera>().maxY = -296;
                break;
            case 341://Коридор Универа слева                
                GetComponent<Transform>().position = new Vector3(-11, -371, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -5.79f;
                camera.GetComponent<MoveCamera>().maxX = 5.72f;
                camera.GetComponent<MoveCamera>().minY = -370;
                camera.GetComponent<MoveCamera>().maxY = -370;
                if (!dm.GetComponent<DialogueManager>().finishedDialogs[39])
                {
                    if (choiser.choisess.Sum() >= 0)
                    {
                        StartCoroutine(StartDialogWithTimer(33, 1f));
                        blackscreen.SetActive(true);
                    }
                    else
                    {
                        qg.OpenQuestWindow(9);
                        dt.currentDialog = 39;
                    }
                }
                else
                {
                    qg.OpenQuestWindow(10);
                }
                break;
            case 342://Коридор Универа справа
                GetComponent<Transform>().position = new Vector3(13, -371, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -5.79f;
                camera.GetComponent<MoveCamera>().maxX = 5.72f;
                camera.GetComponent<MoveCamera>().minY = -370;
                camera.GetComponent<MoveCamera>().maxY = -370;
                break;
            case 351://Коридор Универа слева
                GetComponent<Transform>().position = new Vector3(166, -371, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = 172.76f;
                camera.GetComponent<MoveCamera>().maxX = 176.84f;
                camera.GetComponent<MoveCamera>().minY = -370;
                camera.GetComponent<MoveCamera>().maxY = -370;
                break;
            case 352://Коридор Универа справа
                GetComponent<Transform>().position = new Vector3(184, -371, 1);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = 172.76f;
                camera.GetComponent<MoveCamera>().maxX = 176.84f;
                camera.GetComponent<MoveCamera>().minY = -370;
                camera.GetComponent<MoveCamera>().maxY = -370;
                break;

            default:
                break;
        }

    }

    public IEnumerator StartDialogWithTimer(int id, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dm.GetComponent<DialogueManager>().StartDialogue(id);
    }


    public void MoveOutLobbyToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}