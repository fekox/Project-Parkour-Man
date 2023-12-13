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

    /// <summary>
    /// A sound is played according to the number that comes out of the random.
    /// </summary>
    public void StartSound()
    {
        int maxRange = 5;

        int randNumber = UnityEngine.Random.Range(0, maxRange);

        soundsPlayer.PlaySFX(sfxNames[randNumber]);        
    }

    /// <summary>
    /// If the player arrives before 5 minutes, the sound of the new end is played, 
    /// otherwise the sound of the hand end is played.
    /// </summary>
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