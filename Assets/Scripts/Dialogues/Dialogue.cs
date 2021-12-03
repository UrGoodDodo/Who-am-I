using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Сериализация
[System.Serializable]
public class Dialogue 
{
    [TextArea(3, 10)]
    public string[] sentences;
}
