using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDING : MonoBehaviour
{
    public GameObject camera;
    public GameObject[] endings = new GameObject[4];
    public int id = 0;
    public void END()//0 - ХорошаяХорошая         1 - ПлохаяХорошая       2 - ХорошаяПлохая      3 - ПлохаяПлохая
    {
        switch (id)
        {
            case 0:
                endings[id].SetActive(true);
                camera.GetComponent<Transform>().position = new Vector3(endings[id].GetComponent<Transform>().position.x,
                    endings[id].GetComponent<Transform>().position.y,
                    -10);
                camera.GetComponent<MoveCamera>().minY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().maxY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().minX = endings[id].GetComponent<Transform>().position.x;
                camera.GetComponent<MoveCamera>().maxX = endings[id].GetComponent<Transform>().position.x;
                break;
            case 1:
                endings[id].SetActive(true);
                camera.GetComponent<Transform>().position = new Vector3(endings[id].GetComponent<Transform>().position.x,
                    endings[id].GetComponent<Transform>().position.y,
                    -10);
                camera.GetComponent<MoveCamera>().minY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().maxY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().minX = endings[id].GetComponent<Transform>().position.x;
                camera.GetComponent<MoveCamera>().maxX = endings[id].GetComponent<Transform>().position.x;
                break;
            case 2:
                endings[id].SetActive(true);
                camera.GetComponent<Transform>().position = new Vector3(endings[id].GetComponent<Transform>().position.x,
                    endings[id].GetComponent<Transform>().position.y,
                    -10);
                camera.GetComponent<MoveCamera>().minY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().maxY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().minX = endings[id].GetComponent<Transform>().position.x;
                camera.GetComponent<MoveCamera>().maxX = endings[id].GetComponent<Transform>().position.x;
                break;
            case 3:
                endings[id].SetActive(true);
                camera.GetComponent<Transform>().position = new Vector3(endings[id].GetComponent<Transform>().position.x,
                    endings[id].GetComponent<Transform>().position.y,
                    -10);
                camera.GetComponent<MoveCamera>().minY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().maxY = endings[id].GetComponent<Transform>().position.y;
                camera.GetComponent<MoveCamera>().minX = endings[id].GetComponent<Transform>().position.x;
                camera.GetComponent<MoveCamera>().maxX = endings[id].GetComponent<Transform>().position.x;
                break;
            default:
                break;

        }
    }

}
