using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Open a link.
/// </summary>
public class OpenLink : MonoBehaviour
{
    [SerializeField] private SoundsPlayer soundsPlayer;

    [SerializeField] private string sfxName;

    public void getLink(String linkName) 
    {
        soundsPlayer.PlaySFX(sfxName);

        Application.OpenURL(linkName);
    }
}