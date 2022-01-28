using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCamera : MonoBehaviour
{
    // Добавляем объект, за которым будет двигаться камера
    public Transform target;
    [Header("Camera position restrictions")]
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    void Update()
    {
        UpdateCameraPosition();
    }

    // Изменяем позицию камеры на экране
    void UpdateCameraPosition()
    {
        transform.position = new Vector3(
            // Положение игрового объекта, за которым мы двигаемся
            Mathf.Clamp(target.position.x, minX, maxX),
            Mathf.Clamp(target.position.y, minY, maxY),
            // Положение камеры z должно оставаться неизменным 
            transform.position.z // (если камеры куда-то проваливается, заменить на, например, -10)
          );
    }





}
