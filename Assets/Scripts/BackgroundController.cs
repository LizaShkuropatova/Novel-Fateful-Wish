using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public SpriteRenderer bgSpriteRenderer; //ссылка на компонент SpriteRenderer на объекте BG
    public List<Sprite> bgSprites; //список спрайтов для фоновых картинок

    // Метод для смены фона
    public void ChangeBackground(int index)
    {
        // Проверяем, что индекс в пределах списка спрайтов
        if (index >= 0 && index < bgSprites.Count)
        {
            bgSpriteRenderer.sprite = bgSprites[index];
        }
        else
        {
            Debug.LogError("Недопустимый индекс для смены фона: " + index);
        }
    }
}