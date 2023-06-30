using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTutorialSound : MonoBehaviour
{
    [SerializeField] private SFXPlayer sfxPlayer;    
    [SerializeField] private MusicPlayer musicPlayer;

    void Start()
    {
        //TODO: Fix - Repeated code
        musicPlayer.PlayMusic("Tutorial Music");

        sfxPlayer.PlaySFX("Tutorial Narrator");
    }
}