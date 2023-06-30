using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Fix - Unclear name
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
        //TODO: Fix - Hardcoded value
        if (pl.gameObject.CompareTag("PlayerDie"))
        {
            narratorSound.StartSound();

            //TODO: Fix - Hardcoded value
            sfxPlayer.PlaySFX("Player Die");

            player.transform.position = playerSpawn.transform.position;
        }
    }
}   
