using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TestOnClick : MonoBehaviour
{
    public GameObject enemy;    //Объект, который будет добавлен на сцену
    void Start()
    {

    }

    public Quest quest;

    //Функции спавна объекта, весь скрипт создан как тест
    public void ChangeTransform()
    {
        GetComponent<Transform>().position = new Vector3(1, 1, 1);
    }
    public void ChangeSize()
    {
        GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0);
    }

    public void AddObjInScene()
    {
            Instantiate(enemy);
            GetComponent<Transform>().localScale = new Vector3(6, 6, 1);
            GetComponent<Transform>().position = new Vector3(1, 2.5f, 1);
        if (quest.IsActive)
        {
            //quest.goal.goal = true;
            //if (quest.goal.goal) 
            //{
            //
            //}
            quest.Complete();
        }
    }


}

