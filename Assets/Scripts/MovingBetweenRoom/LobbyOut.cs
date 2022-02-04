using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyOut : MonoBehaviour
{
    public GameObject On;
    public GameObject Out;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Out.SetActive(false);
            On.SetActive(true);
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            On.SetActive(false);
            Out.SetActive(true);
            
        }
    }
}
