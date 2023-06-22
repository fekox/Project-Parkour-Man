using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    private String linkName;

    public SFXPlayer sfxPlayer;

    public void getLink(String linkName) 
    {
        sfxPlayer.PlaySFX("Button");

        Application.OpenURL(linkName);
    }
}