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

    private void OnTriggerEnter(Collider p)
    {
        if (p.gameObject.CompareTag(playerWinTag))
        {
            //TODO: Fix - Should be event based - You can have a class that listenes to the event onWin, same with playerDie
            narratorSound.WinSounds();
            startTimer = true;
        }
    }

    private void Update()
    {
        //TODO: Fix - Could be a coroutine
        if (startTimer == true)
        {
            winTimer -= Time.deltaTime;
        }

        if (winTimer <= 0) 
        {
            //TODO: Fix - Should be event based
            winMenu.WinMenuOn();
        }
    }
}
