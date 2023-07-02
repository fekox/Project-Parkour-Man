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

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void PlayLevel()
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[0]);
    }

    public void Tutorial()
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[1]);
    }

    public void Credits() 
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[2]);

    }

    public void Exit()
    {
        soundsPlayer.PlaySFX(sfxName);

        Application.Quit();
    }

    public void ReturnMenu()
    {
        soundsPlayer.PlaySFX(sfxName);

        SceneManager.LoadScene(scenesNames[3]);
    }
}