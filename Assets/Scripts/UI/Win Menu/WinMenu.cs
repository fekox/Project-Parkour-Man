using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scenes in the win menu.
/// </summary>
public class WinMenu : MonoBehaviour
{
    [SerializeField] private string[] scenesName; 

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scenesName[0]);
    }

    public void WinMenuOn()
    {
        SceneManager.LoadScene(scenesName[1]);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scenesName[2]);
    }
}
