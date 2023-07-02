using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manage the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private SoundsPlayer soundsPlayer;

    [SerializeField] private string sfxName;

    [SerializeField] private string loadSceneName;

    public bool gamePause = false;

    public GameObject pauseMenuUI;

    public void Resume() 
    {
        soundsPlayer.PlaySFX(sfxName);

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePause = false;
    }

    public void Pause()
    {
        soundsPlayer.PlaySFX(sfxName);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePause = true;
    }

    public void LoadMenu()
    {
        soundsPlayer.PlaySFX(sfxName);

        Time.timeScale = 1.0f;

        SceneManager.LoadScene(loadSceneName);
    }

    public void QuitGame() 
    {
        soundsPlayer.PlaySFX(sfxName);

        Application.Quit();
    }
}