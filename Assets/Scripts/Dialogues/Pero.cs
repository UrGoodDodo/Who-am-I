using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pero : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Off.SetActive(false);
            On.SetActive(true);
        }
    }
}
