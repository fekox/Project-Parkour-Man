using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scenes.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private SoundsPlayer soundsPlayer;

    [SerializeField] private GameObject firstSelected;

    [SerializeField] private string sfxName;

    [SerializeField] private string[] scenesNames;

    /// <summary>
    /// A first menu option is set as selected.
    /// </summary>
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void PlayLevel()
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[0]);
    }

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void Tutorial()
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[1]);
    }

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void Credits() 
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[2]);
    }

    /// <summary>
    /// A sound plays and the application is closed.
    /// </summary>
    public void Exit()
    {
        soundsPlayer.PlaySFX(sfxName);

        Application.Quit();
    }

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void ReturnMenu()
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[3]);
    }
}