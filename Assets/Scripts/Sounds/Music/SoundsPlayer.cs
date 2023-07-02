using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play the music and the SFX.
/// </summary>
public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void PlayMusic(string name)
    {
        audioManager.Play(name);
    }

    public void PlaySFX(string name)
    {
        audioManager.Play(name);
    }
}
