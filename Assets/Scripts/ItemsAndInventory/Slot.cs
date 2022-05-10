using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public int itemid;  // Слот следит, какой в нём предмет
    public Sprite defaultMask;  // У слота есть стандартный вид
    public GameObject act2;    //Принимает значение объекта, который будет спавнить
    public Canvas canvas;
    public LighterOnOff Light;
    public GameObject rukzak;
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
        if (itemid == 0)
        {
            GetComponent<Button>().enabled = false;
        }
        if (itemid == 3)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvas.enabled = !canvas.enabled;
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            }
        }

    }
    public void BeforeUsePic()
    {
        if (itemid == 1)
        {

        }
        if (itemid == 2)
        {
            Instantiate(act2); //Спавнит объект на сцене
            act2.GetComponent<Transform>().localScale = new Vector3(6, 6, 1);
            act2.GetComponent<Transform>().position = new Vector3(5, 2.5f, 1);
            GetComponent<Image>().sprite = defaultMask; //Ставит стандартную иконку при отсутствии предмета в слоте
            itemid = 0; //Предмет пропадает из слота, поэтому айди предмета в слоте = 0
        }
        if (itemid == 3)
        {
            canvas.enabled = !canvas.enabled;
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        }
        if (itemid == 4)
        {
            Light.Lighter();
        }
        if (itemid == 5)
        {
            rukzak.SetActive(!rukzak.active);
        }
        if (itemid == 6)
        {

        }

    }


}
