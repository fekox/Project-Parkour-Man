using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorSounds : MonoBehaviour
{

    [SerializeField] private TimerController tM;
    public void StartSound()
    {
        int randNumber = UnityEngine.Random.Range(1, 6);

        switch (randNumber)
        {
            case 1:
                FindAnyObjectByType<AudioManager>().Play("Die Narrator 1");

                break;

            case 2:
                FindAnyObjectByType<AudioManager>().Play("Die Narrator 2");
                break;

            case 3:
                FindAnyObjectByType<AudioManager>().Play("Die Narrator 3");
                break;

            case 4:
                FindAnyObjectByType<AudioManager>().Play("Die Narrator 4");
                break;

            case 5:
                FindAnyObjectByType<AudioManager>().Play("Die Narrator 5");
                break;

        }
    }

    public void WinSounds() 
    {
        if (tM.timerSeg <= 360f) 
        {
            FindAnyObjectByType<AudioManager>().Play("Win in 5 mins");
        }

        else 
        {
            FindAnyObjectByType<AudioManager>().Play("Win in 6 mins");
        }
    }
}
