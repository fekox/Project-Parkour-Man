using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerMovement plMov;
    private PlayerLook plLook;

    void Start()
    {
        plMov = GetComponent<PlayerMovement>();
        plLook = GetComponentInChildren<PlayerLook>();
    }

    public void OnJump()
    {
        plMov.JumpLogic();
    }

    public void OnMove(InputValue value)
    {
        plMov.Movement(value);
    }

    public void OnSprintStart(InputValue value)
    {
        plMov.SprintStartLogic(value);
    }

    public void OnSprintFinish(InputValue value)
    {
        plMov.SprintFinishLogic(value);
    }

    public void OnLook(InputValue inputValue)
    {
        plLook.LookLogic(inputValue);
    }
}
