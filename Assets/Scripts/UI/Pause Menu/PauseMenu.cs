using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePause = false;

    public GameObject pauseMenuUI;

    [SerializeField] private SoundsPlayer soundsPlayer;
    public void Resume() 
    {
        //TODO: Fix - Make const
        soundsPlayer.PlaySFX("Button");

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePause = false;
    }

    public void Pause()
    {
        //TODO: Fix - Make const
        soundsPlayer.PlaySFX("Button");

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePause = true;
    }

    public void LoadMenu()
    {
        //TODO: Fix - Make const
        soundsPlayer.PlaySFX("Button");

        Time.timeScale = 1.0f;
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() 
    {
        //TODO: Fix - Make const
        soundsPlayer.PlaySFX("Button");

        Application.Quit();
    }
}