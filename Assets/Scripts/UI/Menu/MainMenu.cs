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
        sfxPlayer.PlaySFX("Button");

        SceneManager.LoadScene("Level 1");
    }

    public void Tutorial()
    {
        sfxPlayer.PlaySFX("Button");

        SceneManager.LoadScene("Tutorial");
    }

    public void Credits() 
    {
        sfxPlayer.PlaySFX("Button");

        SceneManager.LoadScene("Credits");

    }

    public void Settings() 
    {
        sfxPlayer.PlaySFX("Button");

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

        SceneManager.LoadScene("Menu");
    }
}