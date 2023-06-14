using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    private String linkName;

    public void getLink(String linkName) 
    {
        Application.OpenURL(linkName);
    }
}