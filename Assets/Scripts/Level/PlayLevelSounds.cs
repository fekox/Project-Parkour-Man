using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Start the music and sound effects of level.
/// </summary>
public class PlayLevelSounds : MonoBehaviour
{
    [SerializeField] private SoundsPlayer soundsPlayer;

    [SerializeField] private string sfxName;
    [SerializeField] private string musicName;

    /// <summary>
    /// Play the music and the sfx of the level.
    /// </summary>
    private void Start()
    {
        soundsPlayer.PlaySFX(sfxName);

        soundsPlayer.PlayMusic(musicName);
    }
}
