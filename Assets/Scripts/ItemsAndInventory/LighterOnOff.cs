using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LighterOnOff : MonoBehaviour
{
    public int onoff = 1;	//Определяет, включена или выключена зажигалка
    private Transform lighting;
    private Transform slotLighter;
    public Sprite ON;   // Спрайт, когда зажигалка работает
    public Sprite OFF;  // Спрайт, когда зажигалка не работает
    void Start()
    {
        lighting = GameObject.FindGameObjectWithTag("Lighter").transform;   //Ищем объекты по тегам
        slotLighter = GameObject.FindGameObjectWithTag("SlotLighter").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))    //Включает/Выключает свет на клавишу
        {
            if (onoff == 1)
            {
                lighting.GetComponent<Light>().enabled = true;
                onoff = 2;
                slotLighter.transform.GetChild(0).GetComponent<Image>().sprite = ON;
            }
            else
            {
                lighting.GetComponent<Light>().enabled = false;
                onoff = 1;
                slotLighter.transform.GetChild(0).GetComponent<Image>().sprite = OFF;
            }
        }
    }
    public void Lighter() //Включает/Выключает свет при нажатии на иконку в инвентаре
    {
        if (onoff == 1)
        {
            lighting.GetComponent<Light>().enabled = true;
            onoff = 2;
            slotLighter.transform.GetChild(0).GetComponent<Image>().sprite = ON;
        }
        else
        {
            lighting.GetComponent<Light>().enabled = false;
            onoff = 1;
            slotLighter.transform.GetChild(0).GetComponent<Image>().sprite = OFF;
        }
    }
}
