using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void PlaySFX(string name) 
    {
        audioManager.Play(name);
    }
}
