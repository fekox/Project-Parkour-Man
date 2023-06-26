using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuSound : MonoBehaviour
{
    [SerializeField] private MusicPlayer musicPlayer;

    void Start()
    {
        musicPlayer.PlayMusic("Menu Music");
    }
}