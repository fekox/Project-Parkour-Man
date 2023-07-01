using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Start the music and sound effects of level.
/// </summary>
public class PlayLevelSounds : MonoBehaviour
{
    [SerializeField] private SFXPlayer sfxPlayer;
    [SerializeField] private MusicPlayer musicPlayer;

    [SerializeField] private string sfxName;
    [SerializeField] private string musicName;

    private void Start()
    {
        sfxPlayer.PlaySFX(sfxName);

        musicPlayer.PlayMusic(musicName);
    }
}
