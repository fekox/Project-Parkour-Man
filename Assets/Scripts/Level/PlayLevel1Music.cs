using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel1Music : MonoBehaviour
{
    public SFXPlayer sfxPlayer;
    public MusicPlayer musicPlayer;

    void Start()
    {
        sfxPlayer.PlaySFX("Narrator Level 1");

        //FindAnyObjectByType<AudioManager>().Play("Narrator Level 1");

        musicPlayer.PlayMusic("Music Level 1");
        
        //FindAnyObjectByType<AudioManager>().Play("Music Level 1");
    }
}
