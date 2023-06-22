using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    public float timerSeg;

    private float saveTimerSeg;

    private int segs;
    private int mins;

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