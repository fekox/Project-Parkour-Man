using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerMovement playerMov;

    private PlayerLook playerLook;

    private WallRunning playerWallrun;

    private Running playerRunning;

    private Jumping playerJump;

    [Header("Input Check")]

    //TODO: TP2 - SOLID - These variables should be controlled by this class
    //TODO: TP2 - FSM - Maybe an FSM is what could replace all these booleans
    public bool _isWalkButtonPress;

    public bool _isSprintButtonPress;

    public bool _isJumpingButtonPress;

    public bool _isWallrunning;

    public bool _isFalling;

    public bool climbing;

    private void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
        playerRunning = GetComponent<Running>();
        playerWallrun = GetComponent<WallRunning>();
        playerJump = GetComponent<Jumping>();
        playerLook = GetComponentInChildren<PlayerLook>();

    }

    public void OnJump()
    {
        playerJump.JumpLogic();

        if(_isWallrunning == true)
        {
            playerWallrun.WallJump();
        }
    }

    public void OnMove(InputValue value)
    {
        playerMov.Movement(value);
        playerWallrun.CheckForWall();
        playerWallrun.WallRunLogic();
    }

    public void OnSprintStart()
    {
        playerRunning.SprintStartLogic();   
    }

    public void OnSprintFinish()
    {
        playerRunning.SprintFinishLogic();
    }

    public void OnLook(InputValue inputValue)
    {
        playerLook.LookLogic(inputValue);
    }
}