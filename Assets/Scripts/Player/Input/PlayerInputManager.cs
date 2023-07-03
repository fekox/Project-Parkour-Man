using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls the player inputs that are executed.
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    [Header("References")]

    private PlayerMovement playerMov;

    private PlayerLook playerLook;

    private WallRunning playerWallrun;

    private Running playerRunning;

    private Jumping playerJump;

    /// <summary>
    /// Assign the components.
    /// </summary>
    private void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
        playerRunning = GetComponent<Running>();
        playerWallrun = GetComponent<WallRunning>();
        playerJump = GetComponent<Jumping>();
        playerLook = GetComponentInChildren<PlayerLook>();
    }

    /// <summary>
    /// Functions are called to execute the jump mechanics.
    /// </summary>
    public void OnJump()
    {
        playerJump.JumpLogic();

        if(playerWallrun.isWallrunning == true)
        {
            playerWallrun.WallJump();
        }
    }

    /// <summary>
    /// Functions are called to execute the movement mechanics.
    /// The movement function receives an input.
    /// </summary>
    /// <param name="value"></param>
    public void OnMove(InputValue value)
    {
        playerMov.Movement(value);
        playerWallrun.CheckForWall();
        playerWallrun.WallRunLogic();
    }

    /// <summary>
    /// Function are called to execute the run mechanic.
    /// </summary>
    public void OnSprintStart()
    {
        playerRunning.SprintStartLogic();   
    }

    /// <summary>
    /// Function are called to end the run mechanic.
    /// </summary>
    public void OnSprintFinish()
    {
        playerRunning.SprintFinishLogic();
    }

    /// <summary>
    /// Function are called to execute the camera look mechanic.
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnLook(InputValue inputValue)
    {
        playerLook.LookLogic(inputValue);
    }
}