using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

/// <summary>
/// Controls inputs for cheats.
/// </summary>
public class CheatsManager : MonoBehaviour
{
    [Header("Cheat: God Mode")]
    public bool godMode = false;

    [Header("Cheat: Flash")]
    public bool flash = false;

    [Header("Cheat: Feather Fall")]
    public bool featherFall = false;

    [Header("References")]
    [SerializeField] private GameObject godModeImage;

    [SerializeField] private GameObject flashImage;

    [SerializeField] private GameObject featherFallImage;

    /// <summary>
    /// Active the god mode.
    /// </summary>
    public void GodModeActive()
    {
        godMode = true;
        godModeImage.SetActive(true);
    }

    /// <summary>
    /// Desactive the god mode.
    /// </summary>
    public void GodModeDesactive()
    {
        godMode = false;
        godModeImage.SetActive(false);
    }

    /// <summary>
    /// Active the flash.
    /// </summary>
    public void FlashActive() 
    {
        flash = true;
        flashImage.SetActive(true);
    }

    /// <summary>
    /// Desactive the flash.
    /// </summary>
    public void FlashDesactive() 
    {
        flash = false;
        flashImage.SetActive(false);
    }

    /// <summary>
    /// Active the feather fall.
    /// </summary>
    public void FeatherFallActive()
    {
        featherFall = true;
        featherFallImage.SetActive(true);
    }

    /// <summary>
    /// Desactive the feather fall.
    /// </summary>
    public void FeatherFallDesactive()
    {
        featherFall = false;
        featherFallImage.SetActive(false);
    }
}