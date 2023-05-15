using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float saveTimer;

    private int segs;
    private int mins;

    private void Update()
    {
        saveTimer = PlayerPrefs.GetFloat("Time");

        segs = (int)saveTimer % 60;
        mins = (int)saveTimer / 60;

        timerText.text = string.Format("{00:00}:{1:00}", mins, segs);
    }
}
