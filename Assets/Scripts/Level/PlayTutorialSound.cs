using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTutorialSound : MonoBehaviour
{
    public SFXPlayer sfxPlayer;    
    public MusicPlayer musicPlayer;

    void Start()
    {
        musicPlayer.PlayMusic("Tutorial Music");

        sfxPlayer.PlaySFX("Tutorial Narrator");
    }
}
