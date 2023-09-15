using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

    public GameObject gameOverMenuUI;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
