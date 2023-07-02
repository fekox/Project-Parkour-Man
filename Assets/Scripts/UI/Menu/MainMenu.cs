using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private SoundsPlayer soundsPlayer;

    [SerializeField] private GameObject firstSelected;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void PlayLevel()
    {
        //TODO: Fix - Hardcoded value
        soundsPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Level 1");
    }

    public void Tutorial()
    {
        soundsPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Tutorial");
    }

    public void Credits() 
    {
        soundsPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Credits");

    }

    public void Settings() 
    {
        soundsPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        soundsPlayer.PlaySFX("Button");

        Application.Quit();
    }

    public void ReturnMenu()
    {
        soundsPlayer.PlaySFX("Button");

        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Menu");
    }
}