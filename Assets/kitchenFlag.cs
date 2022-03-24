using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kitchenFlag : MonoBehaviour
{
    public GameObject dm;
    public GameObject player;    

    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (collision.tag == "Player" && !dm.GetComponent<DialogueManager>().finishedFlags[0])
        {           
            dm.GetComponent<DialogueManager>().P_TimeLine.SetActive(false); ;
            dm.GetComponent<DialogueManager>().finishedFlags[0] = true;
            player.GetComponent<Move>().MoveOutLobbyToLocation(-1); // Переход назад в лобби
            StartCoroutine(dm.GetComponent<DialogueManager>().StartDialogWithTimer(4,1f));
        }
    }

    public IEnumerator StartDialogWithTimer(int id, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dm.GetComponent<DialogueManager>().StartDialogue(id);
    }


}
