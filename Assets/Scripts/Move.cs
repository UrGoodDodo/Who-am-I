using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.03f;
    public Sprite stay;
    private float side;
    private Transform LB;
    private Transform RB;
    private Transform TB;
    private Transform DB;
    private void Start()
    {
        LB = GameObject.FindGameObjectWithTag("LB").transform;	//Получение границ карты
        RB = GameObject.FindGameObjectWithTag("RB").transform;
        TB = GameObject.FindGameObjectWithTag("TB").transform;
        DB = GameObject.FindGameObjectWithTag("DB").transform;
    }

    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical") * Time.deltaTime;
        side = Input.GetAxis("Horizontal");

        if (side < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (side > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (GetComponent<Transform>().position.y <= TB.position.y)
        {
            transform.position += new Vector3(0,speed, 0) * Time.deltaTime;
        }
        if (GetComponent<Transform>().position.y >= DB.position.y)
        {
            transform.position += new Vector3(0,-speed, 0) * Time.deltaTime;
        }

        if (GetComponent<Transform>().position.x < RB.position.x-0.8f)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (GetComponent<Transform>().position.x > LB.position.x+0.8f)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            GetComponent<Animator>().enabled = true;
        }
        else
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = stay;
        }

    }
}