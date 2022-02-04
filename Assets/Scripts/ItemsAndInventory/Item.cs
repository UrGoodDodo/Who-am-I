using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite sprite;   //Картинка предмета в слоте
    public int index = 0; //Номер предмета
    private bool touch; //Проверяет наведение курсора на объект
    private Transform player;
    private Transform slot;
  
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Ищем объекты по их тегам
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
        {//Если игрок близко к предмету, то можно будет взаимодействовать с ним
            if ((Mathf.Abs(player.position.x - GetComponent<Transform>().position.x) <= 1.5f) &&
                (Mathf.Abs(player.position.y - GetComponent<Transform>().position.y) <= 2.5f))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    slot.GetComponent<Image>().sprite = sprite; // Меняем картинку на слоте
                    slot.GetComponent<Slot>().itemid = 2;   //Меняем айди предмета в слоте
                    Destroy(gameObject); //Удаление объекта с карты
                    
                }
            }

        }
    }


}
