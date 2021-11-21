using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Подключает библиотеку со скриптами для пользовательского интерфейса

//Наследуем класс DataBase от класса MonoBehaviour
public class DataBase : MonoBehaviour   //MonoBehaviour - базовый класс, от которого наследуются все скрипты https://docs.unity3d.com/ru/530/ScriptReference/MonoBehaviour.html
{
    public List<Item> items = new List<Item>(); //Создаём список объектов items класса Item
}

// Атрибут для сериализации класса Item
[System.Serializable]   //Позволяет Unity увидеть поля и сохранить их значения
//Если его не написать, инспектор не увидит класс Item и не сможет заполнить список в DataBase его объектами
public class Item
{
    public int id;          //Вполне понятные поля, которые содержит класс Item
    public string name;     //(Информация об объекте)
    public Sprite img;      //Инициализация объекта img класса  Sprite
}