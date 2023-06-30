using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorSounds : MonoBehaviour
{

    [SerializeField] private TimerController timerController;

    public SFXPlayer sfxPlayer;
    public void StartSound()
    {
        int randNumber = UnityEngine.Random.Range(1, 6);

        //TODO: TP2 - Strategy - Or simply have an array and play a random index
        switch (randNumber)
        {
            case 1:
                
                //TODO: Fix - Hardcoded value
                sfxPlayer.PlaySFX("Die Narrator 1");
                break;

            case 2:

                sfxPlayer.PlaySFX("Die Narrator 2");
                break;

            case 3:

                sfxPlayer.PlaySFX("Die Narrator 3");
                break;

            case 4:

                sfxPlayer.PlaySFX("Die Narrator 4");
                break;

            case 5:
                
                sfxPlayer.PlaySFX("Die Narrator 5");
                break;

        }
    }

    public void WinSounds() 
    {
        //TODO: Fix - Hardcoded value
        if (timerController.timerSeg <= 360f) 
        {
            //TODO: Fix - Hardcoded value
            sfxPlayer.PlaySFX("Win in 5 mins");
        }

        else 
        {
            //TODO: Fix - Hardcoded value
            sfxPlayer.PlaySFX("Win in 6 mins");
        }
    }
}
