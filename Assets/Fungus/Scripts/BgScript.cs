using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public GameObject bg; // Ссылка на игровой объект с фоном
    public Sprite[] backgrounds; // Массив с картинками для фона

    // Метод для вызова смены фона
    public void CallChange()
    {
        // Загружаем картинку для фона
        Sprite sprite = backgrounds[0]; // Здесь выбираем первую картинку из массива backgrounds
        if (sprite != null)
        {
            // Присваиваем загруженную картинку фону
            bg.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
