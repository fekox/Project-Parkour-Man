using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    private String linkName;

    public SFXManager sfxM;

    public void getLink(String linkName) 
    {
        sfxM.PlaySFX("Button");

        Application.OpenURL(linkName);
    }
}