using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play the music and the SFX.
/// </summary>
public class SoundsPlayer : MonoBehaviour
{
    public AudioManager audioManager;

    /// <summary>
    /// The sound that is given to the function is played.
    /// </summary>
    /// <param name="name"></param>
    public void PlayMusic(string name)
    {
        audioManager.Play(name);
    }

    /// <summary>
    /// The music that is given to the function is played.
    /// </summary>
    /// <param name="name"></param>
    public void PlaySFX(string name)
    {
        audioManager.Play(name);
    }
}
