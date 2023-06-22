using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject playerSpawn;

    [SerializeField] private NarratorSounds narratorSound;

    [Header("SFX Sounds")]

    public SFXPlayer sfxPlayer; 

    private void OnTriggerEnter(Collider pl)
    {
        if (pl.gameObject.CompareTag("PlayerDie"))
        {
            narratorSound.StartSound();

            sfxPlayer.PlaySFX("Player Die");

            player.transform.position = playerSpawn.transform.position;
        }
    }
}   
