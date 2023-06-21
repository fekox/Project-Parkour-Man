using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePause = false;

    public GameObject pauseMenuUI;

    public SFXManager sfxM;
    public void Resume() 
    {
        sfxM.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePause = false;
    }

    public void Pause()
    {
        sfxM.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePause = true;
    }

    public void LoadMenu()
    {
        sfxM.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() 
    {
        sfxM.PlaySFX("Button");

        //FindAnyObjectByType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
