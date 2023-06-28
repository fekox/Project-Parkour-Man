using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel1Music : MonoBehaviour
{
    [SerializeField] private SFXPlayer sfxPlayer;
    [SerializeField] private MusicPlayer musicPlayer;

    private void Start()
    {
        sfxPlayer.PlaySFX("Narrator Level 1");

        musicPlayer.PlayMusic("Music Level 1");
    }
}
