using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private WinMenu wM;

    [SerializeField] private float winTimer;

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
            wM.WinMenuOn();
        }
    }
}
