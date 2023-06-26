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

    private WallRunning playerWallJump;

    private Jumping playerJump;

    [Header("Input Check")]

    public bool _isWalkButtonPress;

    public bool _isSprintButtonPress;

    public bool _isJumpingButtonPress;

    public bool _isWallrunning;

    public bool _isFalling;

    public bool climbing;



    void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
        playerLook = GetComponentInChildren<PlayerLook>();
        playerWallrun = GetComponent<WallRunning>();
        playerWallJump = GetComponent<WallRunning>();
        playerJump = GetComponent<Jumping>();
    }

    public void OnJump()
    {
        playerJump.JumpLogic();

        if(_isWallrunning == true)
        {
            playerWallJump.WallJump();
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
        playerMov.SprintStartLogic();   
    }

    public void OnSprintFinish()
    {
        playerMov.SprintFinishLogic();
    }

    public void OnLook(InputValue inputValue)
    {
        playerLook.LookLogic(inputValue);
    }
}