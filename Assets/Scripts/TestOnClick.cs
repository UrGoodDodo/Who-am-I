using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TestOnClick : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {

    }



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

    }


}

