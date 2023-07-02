using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    [SerializeField] private SoundsPlayer soundsPlayer;

    public void getLink(String linkName) 
    {
        //TODO: Fix - Hardcoded value
        soundsPlayer.PlaySFX("Button");

        Application.OpenURL(linkName);
    }
}