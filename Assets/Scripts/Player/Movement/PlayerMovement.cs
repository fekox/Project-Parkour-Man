using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [Header("Setup")]
    
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform playerCamera;

    [SerializeField] private PlayerInputManager playerIntput;


    [Header("Movement")]
    
    [SerializeField] private float movementSpeed;

    [SerializeField] private float SprintSpeed;

    [SerializeField] private float wallRunningSpeed;

    [SerializeField] private float gravityModifier;

    public Vector3 _currentMovement;

    private float normalSpeed;

    private float maxSpeed;


    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (!rigidBody)
        {
            enabled = false;
        }

        normalSpeed = movementSpeed;

        maxSpeed = normalSpeed + movementSpeed;

        if(playerIntput._isWallrunning == true) 
        {
            movementSpeed = wallRunningSpeed;
        }
    }

    private void FixedUpdate()
    {
        if(_currentMovement.magnitude >= 1f) 
        {
            float targetAngle = Mathf.Atan2(_currentMovement.x, _currentMovement.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigidBody.velocity = moveDir * movementSpeed + Vector3.up * rigidBody.velocity.y;

            if (playerIntput._isFalling == false)
            {
                playerIntput._isWalkButtonPress = true;
            }

            if(playerIntput._isFalling == true) 
            {
                playerIntput._isWalkButtonPress = false;

                rigidBody.AddForce(Vector3.down * gravityModifier, ForceMode.Acceleration);
            }

            if (playerIntput.climbing == true) 
            {
                playerIntput._isSprintButtonPress = false;
            }

            if(playerIntput._isSprintButtonPress == true || playerIntput._isFalling == true) 
            {
                movementSpeed = SprintSpeed;

                if(movementSpeed > maxSpeed) 
                {
                    movementSpeed = normalSpeed;
                }
            }

            else 
            {
                movementSpeed = normalSpeed;
            }

        }

        else 
        {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);

            playerIntput._isWalkButtonPress = false;
            SprintReleased();
        }
    }

    public void Movement(InputValue value)
    {
        var movementInput = value.Get<Vector2>();
        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    public void SprintStartLogic()
    {
        if (playerIntput._isWalkButtonPress == true)
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
        playerIntput._isSprintButtonPress = true;
    }

    private void SprintReleased()
    {
        playerIntput._isSprintButtonPress = false;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            playerIntput._isFalling = false;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            playerIntput._isFalling = true;
        }
    }
}