using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    public void PlaySFX(string name) 
    {
        audioManager.Play(name);
    }
}
