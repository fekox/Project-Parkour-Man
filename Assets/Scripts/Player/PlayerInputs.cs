using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
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

    public void OnSprint(InputValue value)
    {
        plMov.SprintLogic(value);
    }

    public void OnLook(InputValue inputValue)
    {
        plLook.LookLogic(inputValue);
    }
}
