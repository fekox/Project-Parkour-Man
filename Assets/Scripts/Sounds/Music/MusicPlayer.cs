using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void PlayMusic(string name)
    {
        audioManager.Play(name);
    }
}
