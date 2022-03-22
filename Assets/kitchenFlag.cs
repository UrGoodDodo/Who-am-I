using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kitchenFlag : MonoBehaviour
{
    public GameObject dm;
    public GameObject save;
    private bool isFinished = false;

    public void OnTriggerEnter2D(Collider2D collision)	//Происходит при срабатывании тригера коллайдера на объекте
    {
        if (collision.tag == "Player" && !isFinished)
        {
            isFinished = true;
            dm.GetComponent<DialogueManager>().finishedFlags[0] = true;            
            SceneManager.LoadScene(1);           
        }
    }    
}
