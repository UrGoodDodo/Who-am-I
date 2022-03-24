using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject[] cutscene = new GameObject[3];
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player != null) player.GetComponent<Move>().MoveOutLobbyToLocation(0);
            foreach (var item in cutscene)
                item.SetActive(false);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player != null)  player.GetComponent<Move>().MoveOutLobbyToLocation(0);
            foreach (var item in cutscene)
                item.SetActive(false);
        }
    }

}
