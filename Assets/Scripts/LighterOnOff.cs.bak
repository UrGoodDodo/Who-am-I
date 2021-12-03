using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LighterOnOff : MonoBehaviour
{
    public int onoff = 1;
    private Transform lighting;
    private Transform slotLighter;
    public Sprite ON;
    public Sprite OFF;
    void Start()
    {
        lighting = GameObject.FindGameObjectWithTag("Lighter").transform;
        slotLighter = GameObject.FindGameObjectWithTag("SlotLighter").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
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
    public void Lighter()
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
