using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public int id;
    public int itemid;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemid == id)
        {
            GetComponent<Button>().enabled = true;
        }
        
    }
    
    
}
