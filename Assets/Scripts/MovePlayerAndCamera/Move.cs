using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed = 0.03f; //Скорость движения
    public Sprite stay; //Отображение стоящего персонажа
    private float side; //Определяет сторону, в которую смотрит игрок
    public GameObject player;

    public GameObject dm;
    public QuestGiver qg;
    public ClassTest ct;

    public DialogueTriger dt;
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
            case -111:
                GetComponent<Transform>().position = new Vector3(-9, -1, 3.5f);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = 0;
                camera.GetComponent<MoveCamera>().maxY = 0;
                break;
            case -112:
                GetComponent<Transform>().position = new Vector3(4.5f, -1, 3.5f);
                camera.GetComponent<Transform>().position = new Vector3(4.5f, -1, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = 0;
                camera.GetComponent<MoveCamera>().maxY = 0;
                break;

            case 101:
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
            case 102:
                GetComponent<Transform>().position = new Vector3(11, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(0, -100, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                break;

            case 111:
                GetComponent<Transform>().position = new Vector3(180, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(185, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 185.7f;
                camera.GetComponent<MoveCamera>().maxX = 197.9f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                if (!dm.GetComponent<DialogueManager>().finishedDialogs[3])
                    StartCoroutine(StartDialogWithTimer(3, 1f));
                break;
            case 112:
                GetComponent<Transform>().position = new Vector3(205, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(185, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 185.7f;
                camera.GetComponent<MoveCamera>().maxX = 197.9f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                if (qg.player.mainQuest.IsActive && qg.player.mainQuest.questID == 3)
                    qg.CloseQuestWindow(3);
                break;
            case 121:
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
            case 122:
                GetComponent<Transform>().position = new Vector3(413, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(393, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 392.9f;
                camera.GetComponent<MoveCamera>().maxX = 407.1f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                break;
            case 131:
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
            case 132:
                GetComponent<Transform>().position = new Vector3(2, -206.5f, 1);
                camera.GetComponent<Transform>().position = new Vector3(-2.106f, -206.432f, -10);
                camera.GetComponent<MoveCamera>().minX = -2.106f;
                camera.GetComponent<MoveCamera>().maxX = 0.108f;
                camera.GetComponent<MoveCamera>().minY = -206.432f;
                camera.GetComponent<MoveCamera>().maxY = -206.432f;
                break;

            case 141:
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
            case 142:
                GetComponent<Transform>().position = new Vector3(197, -208, 1);
                camera.GetComponent<Transform>().position = new Vector3(186.64f, -110.432f, -10);
                camera.GetComponent<MoveCamera>().minX = 186.65f;
                camera.GetComponent<MoveCamera>().maxX = 188.85f;
                camera.GetComponent<MoveCamera>().minY = -206.43f;
                camera.GetComponent<MoveCamera>().maxY = -206.43f;

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