using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private WinMenu winMenu;

    [SerializeField] private float winTimer;

    [SerializeField] NarratorSounds narratorSound;


    private bool startTimer = false;

    private float winTime = 0;

    private void Start()
    {
        winTime = winTimer;   
    }

    private void OnTriggerEnter(Collider p)
    {
        if (p.gameObject.CompareTag("PlayerWin"))
        {
            narratorSound.WinSounds();
            startTimer = true;
        }
    }

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
