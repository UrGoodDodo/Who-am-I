using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //���������� ���������� �� ��������� ��� ����������������� ����������

//��������� ����� DataBase �� ������ MonoBehaviour
public class DataBase : MonoBehaviour   //MonoBehaviour - ������� �����, �� �������� ����������� ��� ������� https://docs.unity3d.com/ru/530/ScriptReference/MonoBehaviour.html
{
    public List<Item> items = new List<Item>(); //������ ������ �������� items ������ Item
}

// ������� ��� ������������ ������ Item
[System.Serializable]   //��������� Unity ������� ���� � ��������� �� ��������
//���� ��� �� ��������, ��������� �� ������ ����� Item � �� ������ ��������� ������ � DataBase ��� ���������
public class Item
{
    public int id;          //������ �������� ����, ������� �������� ����� Item
    public string name;     //(���������� �� �������)
    public Sprite img;      //������������� ������� img ������  Sprite
}