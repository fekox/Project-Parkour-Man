using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private WinMenu winMenu;

    [SerializeField] private float winTimer;

    [SerializeField] NarratorSounds narratorSound;


    private bool startTimer = false;

    //TODO: TP2 - Remove unused methods/variables/classes
    private float winTime = 0;

    private void Start()
    {
        winTime = winTimer;   
    }

    private void OnTriggerEnter(Collider p)
    {
        //TODO: Fix - Hardcoded value
        if (p.gameObject.CompareTag("PlayerWin"))
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
