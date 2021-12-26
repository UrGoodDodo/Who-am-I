using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCamera : MonoBehaviour
{
    private Transform player;
    private Transform LB;
    private Transform RB;
    private Transform LBC;
    private Transform RBC;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  //Получение объекта игрока по тегу
        LB = GameObject.FindGameObjectWithTag("LB").transform;  //Получение границ, за которые камера не может выходить
        RB = GameObject.FindGameObjectWithTag("RB").transform;
        LBC = GameObject.FindGameObjectWithTag("LBC").transform;
        RBC = GameObject.FindGameObjectWithTag("RBC").transform;
    }
    void Update()
    {
        if ((GetComponent<Transform>().position.x != player.position.x) &&  //Камера двигается за игроком, но не выходит за границы карты
            (RBC.position.x <= RB.position.x) && 
            (LBC.position.x >= LB.position.x))
        {
            transform.position = new Vector3(1, 0,0) * player.position.x;
        }
        if (((RBC.position.x >= RB.position.x) && (player.position.x < GetComponent<Transform>().position.x)) || //Камера снова начинает движение, когда достигла границы карты,                                                                        
            ((LBC.position.x <= LB.position.x) && (player.position.x > GetComponent<Transform>().position.x))) //но игрок прошёл середину камеры в противоположную от границы сторону
        {
            transform.position = new Vector3(1, 0, 0) * player.position.x; //Позиция центра камеры равна позиции игрока
        }

    }
}
