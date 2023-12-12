using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;

/// <summary>
/// Manage all game sounds.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public Sound[] soundsArray;

    private void Awake()
    {
        foreach (Sound sound in soundsArray) 
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string name) 
    {
        StartCoroutine(PlaySound(name));
    }

    private IEnumerator PlaySound(string name)
    {
        Sound newSound = Array.Find(soundsArray, sound => sound.name == name);
        newSound.source.Play();

        yield break;
    }
}
