using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Pause()
    {
        if (!gameIsPaused)
        {
            Debug.Log("Pausing game menu...");
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0.0f;
            gameIsPaused = true;
        }
        else
        {
            Debug.Log("Resuming game ...");
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1.0f;
            gameIsPaused = false;
        }

        
    }

    public void Resume()
    {
        Debug.Log("Resuming game ...");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void Menu()
    {
        Debug.Log("Opening game menu...");
    }

    public void Options()
    {
        Debug.Log("Opening options ...");
    }

    public void Quit()
    {
        Debug.Log("Quitting game ...");
        Application.Quit();
    }
}
