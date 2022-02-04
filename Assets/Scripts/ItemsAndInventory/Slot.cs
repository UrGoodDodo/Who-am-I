using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public int id;  // Слот имеет айди
    public int itemid;  // Слот следит, какой в нём предмет
    public Sprite defaultMask;  // У слота есть стандартный вид
    public GameObject enemy;    //Принимает значение объекта, который будет спавнить
    void Start()
    {
        GetComponent<Button>().enabled = false;
    }

    void Update()
    {
        if (itemid != 0)
        {
            GetComponent<Button>().enabled = true;
        }

    }
    public void BeforeUsePic()
    {
        if (itemid == 2)
        {
            Instantiate(enemy); //Спавнит на сцене объект
            GetComponent<Image>().sprite = defaultMask; //Ставит стандартную иконку при отсутствии предмета в слоте
            itemid = 0; //Предмет пропадает из слота, поэтому айди предмета в слоте = 0
        }

    }


}
