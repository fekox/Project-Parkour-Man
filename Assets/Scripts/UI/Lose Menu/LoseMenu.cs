using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// When the player loses all their lives, the lose scene menu is loaded.
/// </summary>
public class LoseMenu : MonoBehaviour
{
    [SerializeField] private string[] scenesName;

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scenesName[0]);
    }

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void LoadLoseMenu()
    {
        SceneManager.LoadScene(scenesName[1]);
    }

    /// <summary>
    /// A sound plays and the scene loads.
    /// </summary>
    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(scenesName[2]);
    }
}
