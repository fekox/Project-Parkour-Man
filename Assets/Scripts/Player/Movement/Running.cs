using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages the player's running mechanics.
/// </summary>
public class Running : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private float SprintSpeed;

    private float normalSpeed;

    private float maxSpeed;

    public bool isSprinting;


    [Header("References")]

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private Climbing playerClimb;

    public event Action<bool> onRunChange;

    /// <summary>
    /// The normal speed and the maximum 
    /// speed of the player are set.
    /// </summary>
    private void Start()
    {
        normalSpeed = playerMovement.movementSpeed;

        maxSpeed = normalSpeed + playerMovement.movementSpeed;
    }

    /// <summary>
    /// If the player is running his speed increases, if he 
    /// stops running his speed decreases.
    /// </summary>
    private void FixedUpdate()
    {
        if (playerMovement._currentMovement.magnitude >= 1f) 
        {
            if (playerClimb.isClimbing == true)
            {
                isSprinting = false;
            }

            if (isSprinting == true || playerMovement.isFalling == true)
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

    /// <summary>
    /// Start the running logic.
    /// </summary>
    public void SprintStartLogic()
    {
        SprintPressed();
    }

    /// <summary>
    /// Stops the running logic.
    /// </summary>
    public void SprintFinishLogic()
    {
        SprintReleased();
    }

    /// <summary>
    /// If the run key is pressed down the player starts running
    /// and starts the running animation.
    /// </summary>
    private void SprintPressed()
    {
        onRunChange?.Invoke(true);

        isSprinting = true;
    }

    /// <summary>
    /// If the run key is released down the player stop running
    /// and stops the running animation.
    /// </summary>
    private void SprintReleased()
    {
        onRunChange?.Invoke(false);

        isSprinting = false;
    }
}
