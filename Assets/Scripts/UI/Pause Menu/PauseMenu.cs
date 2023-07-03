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

    /// <summary>
    /// Unpauses the game and plays a sound.
    /// </summary>
    public void Resume() 
    {
        soundsPlayer.PlaySFX(sfxName);

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gamePause = false;
    }

    /// <summary>
    /// Pauses the game and plays a sound.
    /// </summary>
    public void Pause()
    {
        soundsPlayer.PlaySFX(sfxName);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        gamePause = true;
    }

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void LoadMenu()
    {
        soundsPlayer.PlaySFX(sfxName);

        Time.timeScale = 1.0f;

        SceneManager.LoadScene(loadSceneName);
    }

    /// <summary>
    /// A sound plays and the application is closed.
    /// </summary>
    public void QuitGame() 
    {
        soundsPlayer.PlaySFX(sfxName);

        Application.Quit();
    }
}