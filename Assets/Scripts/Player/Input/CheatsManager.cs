using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class CheatsManager : MonoBehaviour
{
    [Header("Cheat: God Mode")]
    public bool godMode = false;

    [Header("Cheat: flash")]
    public bool flash = false;

    /// <summary>
    /// Active the god mode.
    /// </summary>
    public void GodModeActive()
    {
        godMode = true;   
    }

    /// <summary>
    /// Desactive the god mode.
    /// </summary>
    public void GodModeDesactive()
    {
        godMode = false;
    }

    /// <summary>
    /// Active the flash.
    /// </summary>
    public void FlashActive() 
    {
        flash = true;
    }

    /// <summary>
    /// Desactive the flash.
    /// </summary>
    public void FlashDesactive() 
    {
        flash = false;
    }
}
