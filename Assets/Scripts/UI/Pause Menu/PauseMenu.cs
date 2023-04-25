using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool gamePause = false;

    public GameObject pauseMenuUI;

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePause = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Tuqui..., Menu");
    }

    public void QuitGmae() 
    {
        Debug.Log("Tuqui..., Quit");
        Application.Quit();
    }
}
