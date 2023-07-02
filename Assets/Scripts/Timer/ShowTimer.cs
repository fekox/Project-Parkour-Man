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
