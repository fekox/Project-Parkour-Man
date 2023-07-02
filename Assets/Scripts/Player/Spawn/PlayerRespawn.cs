using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The player respawn when he collide with a game object.
/// </summary>
public class PlayerRespawn : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject playerSpawn;

    [SerializeField] private NarratorSounds narratorSound;

    [SerializeField] private string playerTagName;

    [SerializeField] private string sfxName;

    [Header("SFX Sounds")]

    [SerializeField] private SoundsPlayer soundsPlayer;

    private void OnTriggerEnter(Collider pl)
    {
        if (pl.gameObject.CompareTag(playerTagName))
        {
            narratorSound.StartSound();

            soundsPlayer.PlaySFX(sfxName);

            player.transform.position = playerSpawn.transform.position;
        }
    }
}   
