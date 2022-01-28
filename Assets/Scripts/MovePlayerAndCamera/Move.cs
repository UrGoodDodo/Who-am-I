using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.03f; //Скорость движения
    public Sprite stay; //Отображение стоящего персонажа
    private float side; //Определяет сторону, в которую смотрит игрок


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
        }
        else
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = stay;
        }

    }

    public void MoveOutLobby()
    {
        GetComponent<Transform>().position = new Vector3(43, -2, 1);
    }
}