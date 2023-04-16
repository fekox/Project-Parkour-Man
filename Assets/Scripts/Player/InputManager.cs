using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerMovement plMov;
    private PlayerLook plLook;
    private WallRunning plWallrun;
    private WallRunning plWallJump;

    void Start()
    {
        plMov = GetComponent<PlayerMovement>();
        plLook = GetComponentInChildren<PlayerLook>();
        plWallrun = GetComponent<WallRunning>();
        plWallJump = GetComponent<WallRunning>();

    }

    public void OnJump()
    {
        plMov.JumpLogic();

        if(plMov._isWallRunning == true)
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