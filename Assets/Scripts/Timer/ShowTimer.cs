using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Shows the time it took the player to win in the win menu.
/// </summary>
public class ShowTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float saveTimer;

    private int seconds;
    private int minutes;

    /// <summary>
    /// Increase time counter in the hud in seconds and minutes.
    /// </summary>
    private void Update()
    {
        int oneMinute = 60;

        saveTimer = PlayerPrefs.GetFloat("Time");

        seconds = (int)saveTimer % oneMinute;
        minutes = (int)saveTimer / oneMinute;

        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }
}