using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePause = false;

    public GameObject pauseMenuUI;

    public SFXPlayer sfxPlayer;
    public void Resume() 
    {
        sfxPlayer.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePause = false;
    }

    public void Pause()
    {
        sfxPlayer.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePause = true;
    }

    public void LoadMenu()
    {
        sfxPlayer.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() 
    {
        sfxPlayer.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
