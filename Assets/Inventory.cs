using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; //Подключает систему событий. Способ отправки событий к объектам в приложении
//Событие происходит в зависимости от  действий пользователя, например: События нажатия кнопки I, чтобы открыть инвентарь. Или событие взятие предмета из инвентаря.
public class Inventory : MonoBehaviour  //Наследуем класс Inventory от класса со скриптами
{
    public DataBase data;   //Информация из скрипта DataBase

    public List<ItemInventory> items = new List<ItemInventory>();   //Список предметов в инвентаре

    public GameObject gameObjShow;  //Игровые объекты, которые должны быть отображены

    public GameObject InventoryMainObject;  //Предмет в инвентаре

    public int maxCount;    //Максимальное количество элементов в ячейке

    public Camera cam;  //К этой переменной привязана камера
    public EventSystem es;  //Сюда привязали систему событий

    public int currentID;
    public ItemInventory currentItem;

    public RectTransform movingObject;  //Позволит перемещать  объект и держать его на курсоре
    public Vector3 offset;  //Смещает объект, когда поднимаем его курсором

    public GameObject backGround;

    public void Start()
    {
        if (items.Count == 0)
        {
            AddGraphics();
        }

        for (int i = 0; i < maxCount; i++)    //Заполняет ячейки рандомными предметы с рандомным количеством
        {
            AddItem(i, data.items[Random.Range(0, data.items.Count)], Random.Range(1, 99));
        }
        UpdateInventory();
    }

    public void Update()
    {
        if (currentID != -1)
        {
            MoveObject();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            backGround.SetActive(!backGround.activeSelf);
            if (backGround.activeSelf)
            {
                UpdateInventory();
            }
        }
    }

    public void SearchForSameItem(Item item, int count)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id == item.id)
            {
                if (items[0].count < 128)
                {
                    items[i].count += count;

                    if (items[i].count > 128)
                    {
                        count = items[i].count - 128;
                        items[i].count = 64;
                    }
                    else
                    {
                        count = 0;
                        i = maxCount;
                    }
                }
            }
        }

        if (count > 0)
        {
            for (int i = 0; i < maxCount; i++)
            {
                if (items[i].id == 0)
                {
                    AddItem(i, item, count);
                    i = maxCount;
                }
            }
        }
    }


    public void AddItem(int id, Item item, int count)   //Обновление информации о предмете
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.img;

        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();   
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    public void AddInventoryItem(int id, ItemInventory invItem) //Добавление предмета в инвентарь
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;

        if (invItem.count > 1 && invItem.id != 0)//Пишет количество предметов в слоте, если это не пустой слот и предметов больше 1
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }


    public void AddGraphics()   //Отвечает за изображение в каждой ячейке
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject; //Отвечает за перемещение игрового объекта в инвентаре

            newItem.name = i.ToString();    //Имя объекта

            ItemInventory ii = new ItemInventory(); //Создание объекта класса ItemInventory
            ii.itemGameObj = newItem;   //ii как игровой объект является newItem

            RectTransform rt = newItem.GetComponent<RectTransform>(); //Информация о положении объекта, привязке,повороте, размере объекта как прямоугольника
            rt.localPosition = new Vector3(0, 0, 0);    //Айтем находится в своих локальных координатах
            rt.localScale = new Vector3(1, 1, 1);   //Айтем имеет 100% размеры по  всем осям
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);  //Когда добавляем элемент или берём его курсором - размер не меняется

            Button tempButton = newItem.GetComponent<Button>(); //Каждый пункт в инвентаре это кнопка

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);  //В список items добавляем ii
        }
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }

            items[i].itemGameObj.GetComponent<Image>().sprite = data.items[items[i].id].img;
        }
    }

    public void SelectObject()
    {
        if (currentID == -1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].img;

            AddItem(currentID, data.items[0], 0);
        }
        else
        {
            ItemInventory II = items[int.Parse(es.currentSelectedGameObject.name)];


                if (currentItem.id != II.id)
            {
                AddInventoryItem(currentID, II);

                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            }
            else
            {
                if (II.count + currentItem.count <= 128)
                {
                    II.count += currentItem.count;
                }
                else
                {
                    AddItem(currentID, data.items[II.id], II.count + currentItem.count - 128);
                    II.count = 128;
                }

                II.itemGameObj.GetComponentInChildren<Text>().text = II.count.ToString();

            }

            currentID = -1;

            movingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset; //Там где находится курсор идёт смещение на offset
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z; //Получили позицию предмета в инвентаре относительно координаты Z
        movingObject.position = cam.ScreenToWorldPoint(pos);    //Перемещение объекта происходит относительно камеры
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)   //Функция, запоминает информацию о предмете, чтобы она сохранилась при переносе из ячейки в ячейку
    {
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;

        return New;
    }
}

[System.Serializable]   //Позволит видеть поля и сохранять их значения

public class ItemInventory  //Предметы в инвентаре
{
    public int id;  //Айди предмета
    public GameObject itemGameObj;  //Позволит работать с объектом и его компонентами

    public int count;       //Показывает сколько элементов в стаке
}
