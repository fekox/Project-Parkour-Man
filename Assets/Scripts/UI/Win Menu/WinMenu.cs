using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Level 1");
    }

    public void WinMenuOn()
    {
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Win Menu");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene("Menu");
    }
}
