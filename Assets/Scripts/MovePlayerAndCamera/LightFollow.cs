using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Ищет игрока по тегу
    }

    void Update()
    {
        GetComponent<Transform>().position = new Vector3(player.position.x, player.position.y, -10);    //Свет следует за игроком
    }


}

