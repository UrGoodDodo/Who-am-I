using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.03f;
    public Sprite stay;
    private float side;
    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal");
        transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical");
        side = Input.GetAxis("Horizontal");

        if (side < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (side > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (GetComponent<Transform>().position.y <= 0.7f)
        {
            transform.position += new Vector3(0,speed, 0);
        }
        if (GetComponent<Transform>().position.y >= -3)
        {
            transform.position += new Vector3(0,-speed, 0);
        }

        if (GetComponent<Transform>().position.x < 13)
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (GetComponent<Transform>().position.x > -13)
        {
            transform.position += new Vector3(-speed, 0, 0);
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