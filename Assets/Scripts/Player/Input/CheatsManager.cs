using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class CheatsManager : MonoBehaviour
{
    public bool godMode = false;

    /// <summary>
    /// Active the god mode.
    /// </summary>
    public void GodModeActive()
    {
        godMode = true;   
    }

    /// <summary>
    /// Desactive the go mode.
    /// </summary>
    public void GodModeDesactive()
    {
        godMode = false;
    }
}
