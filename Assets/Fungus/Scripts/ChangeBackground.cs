using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public Texture2D backgroundTexture; // Змінна для збереження текстури фону

    public void Change()
    {
        // Отриання об'єкту з фоновою текстурою
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Зміна текстури фона на основі значення змінної backgroundTexture
            renderer.material.mainTexture = backgroundTexture;
        }
    }
}
