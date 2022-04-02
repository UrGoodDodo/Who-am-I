using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject[] cutscene = new GameObject[3];
    public GameObject[] OnObj = new GameObject[3];
    public GameObject playcamera;
    public GameObject newPlayer;
    public GameObject slot;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player != null) player.GetComponent<Move>().MoveOutLobbyToLocation(101);
            foreach (var item in cutscene)
                item.SetActive(false);
            foreach (var item in OnObj)
                item.SetActive(true);
            if (playcamera != null && newPlayer != null)
            {
                playcamera.GetComponent<MoveCamera>().target = newPlayer.transform;
                newPlayer.GetComponent<Move>().MoveOutLobbyToLocation(101);
            }
            slot.GetComponent<LighterOnOff>().enabled = false;

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (player != null) player.GetComponent<Move>().MoveOutLobbyToLocation(101);
            foreach (var item in cutscene)
                item.SetActive(false);
            foreach (var item in OnObj)
                item.SetActive(true);
            if (playcamera != null && newPlayer != null)
            {
                playcamera.GetComponent<MoveCamera>().target = newPlayer.transform;
                newPlayer.GetComponent<Move>().MoveOutLobbyToLocation(101);
            }
            slot.GetComponent<LighterOnOff>().enabled = false;
        }
    }

}
