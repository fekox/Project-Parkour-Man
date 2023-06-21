using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SFXManager sfxM;

    [SerializeField] private GameObject firstSelected;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public void PlayLevel()
    {
        sfxM.PlaySFX("Button");

        SceneManager.LoadScene("Level 1");
    }

    public void Tutorial()
    {
        sfxM.PlaySFX("Button");

        SceneManager.LoadScene("Tutorial");
    }

    public void Credits() 
    {
        sfxM.PlaySFX("Button");

        SceneManager.LoadScene("Credits");

    }

    public void Settings() 
    {
        sfxM.PlaySFX("Button");

        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        sfxM.PlaySFX("Button");

        Application.Quit();
    }

    public void ReturnMenu()
    {
        sfxM.PlaySFX("Button");

        SceneManager.LoadScene("Menu");
    }

}
