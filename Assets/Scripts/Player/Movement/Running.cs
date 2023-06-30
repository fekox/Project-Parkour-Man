using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Running : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private float SprintSpeed;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerInputManager playerInput;

    private float normalSpeed;

    private float maxSpeed;


    private void Start()
    {
        normalSpeed = playerMovement.movementSpeed;

        maxSpeed = normalSpeed + playerMovement.movementSpeed;
    }

    private void FixedUpdate()
    {
        if (playerMovement._currentMovement.magnitude >= 1f) 
        {
            //TODO: TP2 - SOLID
            if (playerInput.climbing == true)
            {
                playerInput._isSprintButtonPress = false;
            }
            if (playerInput._isSprintButtonPress == true || playerInput._isFalling == true)
            {
                playerMovement.movementSpeed = SprintSpeed;

                if (playerMovement.movementSpeed > maxSpeed)
                {
                    playerMovement.movementSpeed = normalSpeed;
                }
            }

            else
            {
                playerMovement.movementSpeed = normalSpeed;
            }
        }

        else 
        {
            SprintReleased();
        }
    }

    public void SprintStartLogic()
    {
        if (playerInput._isWalkButtonPress == true)
        {
            SprintPressed();
        }
    }

    public void SprintFinishLogic()
    {
        SprintReleased();
    }

    private void SprintPressed()
    {
        playerInput._isSprintButtonPress = true;
    }

    private void SprintReleased()
    {
        //TODO: TP2 - FSM
        playerInput._isSprintButtonPress = false;
    }
}
