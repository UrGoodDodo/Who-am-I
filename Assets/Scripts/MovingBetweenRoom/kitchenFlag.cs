using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kitchenFlag : MonoBehaviour
{
    public GameObject dm;
    public GameObject player;
    public GameObject OutOfLobby;
    public GameObject offplayer;
    public GameObject camera;
    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (collision.tag == "Player" && !dm.GetComponent<DialogueManager>().finishedFlags[0])
        {
            dm.GetComponent<DialogueManager>().P_TimeLine.SetActive(false); ;
            dm.GetComponent<DialogueManager>().finishedFlags[0] = true;
            OutOfLobby.SetActive(true);
            player.SetActive(true);
            offplayer.SetActive(false);
            camera.GetComponent<MoveCamera>().target = player.transform;
            player.GetComponent<Move>().MoveOutLobbyToLocation(-112); // Переход назад в лобби
            StartCoroutine(dm.GetComponent<DialogueManager>().StartDialogWithTimer(4, 1f));
        }
    }

    public IEnumerator StartDialogWithTimer(int id, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dm.GetComponent<DialogueManager>().StartDialogue(id);
    }


}
