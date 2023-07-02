using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When the player is dead a random sound is played.
/// If the player win before 5 mins, he had a good ending sound 
/// but if the player win after 5 mins, he had a bad ending spund.
/// </summary>
public class NarratorSounds : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private TimerController timerController;

    [SerializeField] private SoundsPlayer soundsPlayer;

    [Header("Setup")]

    [SerializeField] private string[] sfxNames;

    [SerializeField] private float timeToWin;

    [Header("Sounds of good and bad end")]

    [SerializeField] private string sxfNameGoodEnd;

    [SerializeField] private string sxfNameBadEnd;

    public void StartSound()
    {
        int randNumber = UnityEngine.Random.Range(0, 5);

        for (int i = 0; i < 1; i++) 
        {
            soundsPlayer.PlaySFX(sfxNames[randNumber]);
        }
    }

    public void WinSounds() 
    {
        if (timerController.timerSeg <= timeToWin)
        {
            soundsPlayer.PlaySFX(sxfNameGoodEnd);
        }

        else 
        {
            soundsPlayer.PlaySFX(sxfNameBadEnd);
        }
    }
}
