using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject playerSpawn;

    [SerializeField] private NarratorSounds Ns;

    [Header("SFX Sounds")]

    public SFXPlayer sfxPlayer; 

    private void OnTriggerEnter(Collider p)
    {
        if (p.gameObject.CompareTag("PlayerDie"))
        {
            Ns.StartSound();

            sfxPlayer.PlaySFX("Player Die");

            //FindAnyObjectByType<AudioManager>().Play("Player Die");
            player.transform.position = playerSpawn.transform.position;
        }
    }
}   
