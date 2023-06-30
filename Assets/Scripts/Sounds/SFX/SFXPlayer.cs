using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Fix - Repeated code - Could be the same class as MusicPlayer
public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void PlaySFX(string name) 
    {
        audioManager.Play(name);
    }
}
