using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [Header("References")]
    private PlayerMovement plMov;
    private PlayerLook plLook;
    private WallRunning plWallrun;
    private WallRunning plWallJump;

    private Jumping plJump;

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

        if(plMov._isWallrunning == true)
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