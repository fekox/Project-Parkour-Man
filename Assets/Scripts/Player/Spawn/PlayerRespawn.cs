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

    [SerializeField] private CheatsManager cheatsManager;

    [SerializeField] private string obstacleTagName;

    [SerializeField] private string bulletTagName;

    [SerializeField] private string sfxName;

    [Header("SFX Sounds")]

    [SerializeField] private SoundsPlayer soundsPlayer;


    /// <summary>
    /// If the player collides with the object the player returns to the starting 
    /// position and the narrator sound is played along with the player die sound.
    /// </summary>
    /// <param name="obstacle"></param>
    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.CompareTag(obstacleTagName))
        {
            narratorSound.StartSound();

            soundsPlayer.PlaySFX(sfxName);

            player.transform.position = playerSpawn.transform.position;
        }

        if (obstacle.gameObject.CompareTag(bulletTagName))
        {
            soundsPlayer.PlaySFX(sfxName);

            if (cheatsManager.godMode == false) 
            {
                narratorSound.StartSound();

                player.transform.position = playerSpawn.transform.position;
            }
        }
    }
}   
