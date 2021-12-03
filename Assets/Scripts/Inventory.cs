using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private Canvas canvas;

	void Start()
	{
		canvas = GetComponent<Canvas>(); //Получение компонента Canvas
		canvas.enabled = false; //Отключение инвентаря при старте
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			canvas.enabled = !canvas.enabled; //При нажатии на кнопку I окно будет отображаться или скрываться
		}


	}
}
