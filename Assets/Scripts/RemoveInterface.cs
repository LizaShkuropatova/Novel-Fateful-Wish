using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInterface : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }
}
