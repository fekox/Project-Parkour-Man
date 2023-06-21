using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuSound : MonoBehaviour
{
    public MusicManager musicM;

    void Start()
    {
        musicM.PlayMusic("Menu Music");

        //FindAnyObjectByType<AudioManager>().Play("Menu Music");
    }
}
