using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float timerSeg;

    void Update()
    {
        timerSeg += Time.deltaTime;

        timerText.text = string.Format("{00:00}", timerSeg);
    }
}
