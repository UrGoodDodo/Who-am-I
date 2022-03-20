using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffFon : MonoBehaviour
{

    public GameObject Fon;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Fon.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Fon.SetActive(false);
    }
}

