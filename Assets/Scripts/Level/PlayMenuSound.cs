using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuSound : MonoBehaviour
{
    public MusicPlayer musicPlayer;

    void Start()
    {
        musicPlayer.PlayMusic("Menu Music");
    }
}