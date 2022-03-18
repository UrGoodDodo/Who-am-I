using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltips : MonoBehaviour
{
    public GameObject LightTip;
    public GameObject PickupTip;
    public GameObject InventoryTip;

    // First tip is light, second is pickup and last one is inventory

    public static bool[] IsTipsShowed;
    public static bool[] IsTipsBlocked;
    public GameObject[] Tips;    

    private Transform player;
    private Transform item;
    // Происходит при запуске  
    private void Start()
    {
        Tips = new GameObject[] { LightTip, PickupTip, InventoryTip };

        IsTipsShowed = new bool[] { false, false, false };
        IsTipsBlocked = new bool[] { false, false, false };

        player = GameObject.FindGameObjectWithTag("Player").transform;
        item = GameObject.FindGameObjectWithTag("Item").transform;

        StartCoroutine(ShowLightTip(15f));
    }
    // Происходит каждый кадр
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.F) && IsTipsShowed[0] && !IsTipsBlocked[0])
            HideTip(0);

        if (!IsTipsShowed[1])
            CheckItemPosition();

        if (Input.GetKey(KeyCode.Mouse0) && IsTipsShowed[1] && !IsTipsBlocked[1])
            HideTip(1);

        if (IsTipsBlocked[1] && !IsTipsShowed[2])
            ShowTip(2);

        if (Input.GetKeyDown(KeyCode.I) && IsTipsShowed[2] && !IsTipsBlocked[2])
            HideTip(2);
    }

    //shows a tooltip to turn on the light
    void ShowTip(int id)
    {
        Tips[id].SetActive(true);
        IsTipsShowed[id] = true;
    }

    //hides a tooltip to turn on the light
    void HideTip(int id)
    {
        Tips[id].SetActive(false);
        IsTipsBlocked[id] = true;

    }

    void CheckItemPosition()
    {
        if ((Mathf.Abs(player.position.x - item.position.x) <= 1.5f) && (Mathf.Abs(player.position.y - item.position.y) <= 2.5f) && IsTipsBlocked[0])
            ShowTip(1);
    }
    
    IEnumerator ShowLightTip(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        ShowTip(0);
    }
}
