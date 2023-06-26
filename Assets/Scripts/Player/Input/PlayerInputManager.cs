using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerMovement plMov;

    private PlayerLook plLook;

    private WallRunning plWallrun;

    private WallRunning plWallJump;

    private Jumping plJump;

    [Header("Input Check")]

    public bool _isWalkButtonPress;

    public bool _isSprintButtonPress;

    public bool _isJumpingButtonPress;

    public bool _isWallrunning;

    public bool _isFalling;

    public bool climbing;



    void Start()
    {
        plMov = GetComponent<PlayerMovement>();
        plLook = GetComponentInChildren<PlayerLook>();
        plWallrun = GetComponent<WallRunning>();
        plWallJump = GetComponent<WallRunning>();
        plJump = GetComponent<Jumping>();
    }

    public void OnJump()
    {
        plJump.JumpLogic();

        if(_isWallrunning == true)
        {
            plWallJump.WallJump();
        }
    }

    public void OnMove(InputValue value)
    {
        plMov.Movement(value);
        plWallrun.CheckForWall();
        plWallrun.WallRunLogic();
    }

    public void OnSprintStart()
    {
        plMov.SprintStartLogic();   
    }

    public void OnSprintFinish()
    {
        plMov.SprintFinishLogic();
    }

    public void OnLook(InputValue inputValue)
    {
        plLook.LookLogic(inputValue);
    }
}