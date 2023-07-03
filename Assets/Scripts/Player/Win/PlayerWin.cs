using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When the player collide with a game object the win menu scene is loaded. 
/// </summary>
public class PlayerWin : MonoBehaviour
{
    [SerializeField] private WinMenu winMenu;

    [SerializeField] private float winTimer;

    [SerializeField] NarratorSounds narratorSound;

    [SerializeField] private string playerWinTag;

    private bool startTimer = false;

    /// <summary>
    /// If the player collides with the game object, the timer starts 
    /// and the narrator sound plays.
    /// </summary>
    /// <param name="p"></param>
    private void OnTriggerEnter(Collider p)
    {
        if (p.gameObject.CompareTag(playerWinTag))
        {
            narratorSound.WinSounds();
            startTimer = true;
        }
    }

    /// <summary>
    /// Start the counter to start the win menu.
    /// If the counter is less than or equal to zero, the win menu scene is loaded.
    /// </summary>
    private void Update()
    {
        if (startTimer == true)
        {
            winTimer -= Time.deltaTime;
        }

        if (winTimer <= 0) 
        {
            winMenu.WinMenuOn();
        }
    }
}
