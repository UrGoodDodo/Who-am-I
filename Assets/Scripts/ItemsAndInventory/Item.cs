using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Item : MonoBehaviour
{
    public Sprite[] sprite;   //Картинка предмета в слоте
    public int index = 0; //Номер предмета
    private bool touch; //Проверяет наведение курсора на объект
    public GameObject player;
    public GameObject item;
    public GameObject slot;

    public GameObject OutRoom;

    public Player pl;
    public QuestGiver qg;

    public Text rucsack;

    public DialogueManager dm;

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
            if (item != null)
                if ((Mathf.Abs(player.GetComponent<Transform>().position.x - item.GetComponent<Transform>().position.x) <= 2.5f) &&
            (Mathf.Abs(player.GetComponent<Transform>().position.y - item.GetComponent<Transform>().position.y) <= 2.5f))
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        if (index == 1)
                        {
                            slot.GetComponent<Image>().sprite = sprite[index]; // Меняем картинку на слоте
                            slot.GetComponent<Slot>().itemid = 1;   //Меняем айди предмета в слоте
                            OutRoom.SetActive(true);
                            Destroy(item); //Удаление объекта с карты
                            pl.mainQuest.numericGoal += 1;
                            rucsack.color = new Color(128 / 255.0f, 128 / 255.0f, 128 / 255.0f);
                            if (player.GetComponent<Player>().mainQuest.numericGoal == 2)
                                qg.OpenExtraQuestWindow(0);
                        }
                        if (index == 2)
                        {
                            slot.GetComponent<Image>().sprite = sprite[index]; // Меняем картинку на слоте
                            slot.GetComponent<Slot>().itemid = 2;   //Меняем айди предмета в слоте
                            Destroy(item); //Удаление объекта с карты

                        }
                        if (index == 3)
                        {
                            slot.GetComponent<Image>().sprite = sprite[index]; // Меняем картинку на слоте
                            slot.GetComponent<Slot>().itemid = 2;   //Меняем айди предмета в слоте
                            OutRoom.SetActive(true);
                            Destroy(item); //Удаление объекта с карты
                            pl.extraQuest.numericGoal += 1;
                            qg.CloseExtraQuestWindow(0);
                        }
                        if (index == 4)
                        {
                            slot.GetComponent<Image>().sprite = sprite[index]; // Меняем картинку на слоте
                            slot.GetComponent<Slot>().itemid = 5;   //Меняем айди предмета в слоте
                            Destroy(item); //Удаление объекта с карты
                        }
                        if (index == 5)
                        {
                            slot.GetComponent<Image>().sprite = sprite[index]; // Меняем картинку на слоте
                            slot.GetComponent<Slot>().itemid = 6;   //Меняем айди предмета в слоте
                            Destroy(item); //Удаление объекта с карты
                            OutRoom.GetComponent<Transform>().position = new Vector3(12.63f, 0, 126.4341f);
                            OutRoom.GetComponent<Transform>().position -= new Vector3(1, 294, 0);
                        }
                        if (index == 6) //Мусор
                        {
                            slot.GetComponent<Image>().sprite = sprite[0]; // Меняем картинку на слоте
                            slot.GetComponent<Slot>().itemid = 0;   //Меняем айди предмета в слоте
                            OutRoom.SetActive(true);
                            //if (FindObjectOfType<Choiser>().choisess.Sum() >= 0) 
                            dm.StartDialogue(49);
                            FindObjectOfType<QuestGiver>().CloseExtraQuestWindow(2);
                        }
                        if (index == 7)
                        {
                            dm.StartDialogue(34);
                        }

                    }
                }

        }
    }


}
