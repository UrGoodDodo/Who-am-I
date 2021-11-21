using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 0.03f;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if ((GetComponent<Transform>().position.x != player.position.x) && 
            (player.position.x <= 4.5f) && 
            (player.position.x >= -4.5f))
        {
            transform.position = new Vector3(speed, 0,0) * player.position.x;
        }
            
    }
}
