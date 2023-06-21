using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel1Music : MonoBehaviour
{
    public SFXManager sfxM;
    public MusicManager musicM;

    void Start()
    {
        sfxM.PlaySFX("Narrator Level 1");

        //FindAnyObjectByType<AudioManager>().Play("Narrator Level 1");

        musicM.PlayMusic("Music Level 1");
        
        //FindAnyObjectByType<AudioManager>().Play("Music Level 1");
    }
}
