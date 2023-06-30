using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SFXPlayer sfxPlayer;

    [SerializeField] private GameObject firstSelected;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void PlayLevel()
    {
        //TODO: Fix - Hardcoded value
        sfxPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Level 1");
    }

    public void Tutorial()
    {
        sfxPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Tutorial");
    }

    public void Credits() 
    {
        sfxPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Credits");

    }

    public void Settings() 
    {
        sfxPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        sfxPlayer.PlaySFX("Button");

        Application.Quit();
    }

    public void ReturnMenu()
    {
        sfxPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Menu");
    }
}