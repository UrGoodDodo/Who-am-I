using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite sprite;
    public int index = 0; //Номер предмета
    private bool touch;
    private Transform player;
    private Transform slot;
  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        slot = GameObject.FindGameObjectWithTag("Slot").transform;
    }
    
    void OnMouseEnter()
    {
        touch = true;

    }
    void OnMouseExit()
    {
        touch = false;

    }
    void Update()
    {
        if (touch == true)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            if ((Mathf.Abs(player.position.x - GetComponent<Transform>().position.x) <= 1.5f) &&
                (Mathf.Abs(player.position.y - GetComponent<Transform>().position.y) <= 2.5f))
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    slot.GetComponent<Image>().sprite = sprite;
                    slot.GetComponent<Slot>().itemid = 2;
                    Destroy(gameObject); //Удаление объекта с карты
                    
                }
            }

        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }


}
