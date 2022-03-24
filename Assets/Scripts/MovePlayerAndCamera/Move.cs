using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public float speed = 0.03f; //Скорость движения
    public Sprite stay; //Отображение стоящего персонажа
    private float side; //Определяет сторону, в которую смотрит игрок

    public GameObject dm; 

    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal") * Time.deltaTime;  //Движение влево/вправо на стандартные клавиши
        transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical") * Time.deltaTime;    //Движение вверх/вниз на стандартные клавиши
        side = Input.GetAxis("Horizontal"); //Определяет, в какую сторону последней смотрел игрок при движении

        if (side < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (side > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            GetComponent<Animator>().enabled = true;   //Включает анимацию при движении
            GetComponent<AudioSource>().playOnAwake = true;
            GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = stay;
            GetComponent<AudioSource>().enabled = false;
        }

    }
    public GameObject camera;
    public void MoveOutLobbyToLocation(int index)
    {

        switch (index)
        {
            case -1:                
                GetComponent<Transform>().position = new Vector3(-304, 14, 3.5f);
                camera.GetComponent<Transform>().position = new Vector3(-304, 14, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = 14;
                camera.GetComponent<MoveCamera>().maxY = 14;
                break;                
            case 0:
                GetComponent<Transform>().position = new Vector3(0, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(0, -100, -10);
                camera.GetComponent<MoveCamera>().minX = -4.6f;
                camera.GetComponent<MoveCamera>().maxX = 4.6f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                StartCoroutine(StartDialogWithTimer(2, 3f));
                break;
            case 1:
                GetComponent<Transform>().position = new Vector3(190, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(185, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 185.7f;
                camera.GetComponent<MoveCamera>().maxX = 197.9f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                StartCoroutine(StartDialogWithTimer(3,1f));
                break;
            case 2:
                GetComponent<Transform>().position = new Vector3(393, -102, 1);
                camera.GetComponent<Transform>().position = new Vector3(393, -100, -10);
                camera.GetComponent<MoveCamera>().minX = 392.9f;
                camera.GetComponent<MoveCamera>().maxX = 407.1f;
                camera.GetComponent<MoveCamera>().minY = -100;
                camera.GetComponent<MoveCamera>().maxY = -100;
                break;
            case 3:
                GetComponent<Transform>().position = new Vector3(-2, -208, 1);
                camera.GetComponent<Transform>().position = new Vector3(-2.106f, -206.432f, -10);
                camera.GetComponent<MoveCamera>().minX = -2.106f;
                camera.GetComponent<MoveCamera>().maxX = 0.108f;
                camera.GetComponent<MoveCamera>().minY = -206.432f;
                camera.GetComponent<MoveCamera>().maxY = -206.432f;

                break;
            case 4:
                GetComponent<Transform>().position = new Vector3(187f, -208, 1);
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