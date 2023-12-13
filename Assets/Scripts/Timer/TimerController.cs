using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the time on the screen in the level 1.
/// </summary>
public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    public float timerSeg;

    private float saveTimerSeg;

    private int seconds;
    private int minutes;

    /// <summary>
    /// Shows the time the player got in the win menu.
    /// </summary>
    void Update()
    {
        int oneMinute = 60;

        timerSeg += Time.deltaTime;
        
        saveTimerSeg = timerSeg;

        seconds = (int)timerSeg % oneMinute;
        minutes = (int)timerSeg / oneMinute;

        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
        PlayerPrefs.SetFloat("Time", saveTimerSeg);
    }
}