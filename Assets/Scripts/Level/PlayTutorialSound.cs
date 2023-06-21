using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTutorialSound : MonoBehaviour
{
    public SFXManager sfxM;    
    public MusicManager musicM;

    void Start()
    {
        musicM.PlayMusic("Tutorial Music");

        //FindAnyObjectByType<AudioManager>().Play("Tutorial Music");

        sfxM.PlaySFX("Tutorial Narrator");

        //FindAnyObjectByType<AudioManager>().Play("Tutorial Narrator");
    }
}
