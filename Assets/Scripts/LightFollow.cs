using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Ищет игрока по тегу
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector3(player.position.x, player.position.y, -10);
    }


}

