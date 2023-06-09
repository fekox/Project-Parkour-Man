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

    private int segs;
    private int mins;

    /// <summary>
    /// Shows the time the player got in the win menu.
    /// </summary>
    void Update()
    {
        timerSeg += Time.deltaTime;
        
        saveTimerSeg = timerSeg;

        segs = (int)timerSeg % 60;
        mins = (int)timerSeg / 60;

        timerText.text = string.Format("{00:00}:{1:00}", mins, segs);
        PlayerPrefs.SetFloat("Time", saveTimerSeg);
    }
}