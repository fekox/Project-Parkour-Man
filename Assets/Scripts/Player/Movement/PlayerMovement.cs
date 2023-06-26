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


    [Header("Movement")]

    [SerializeField] private float gravityModifier;

    public float movementSpeed;

    public Vector3 _currentMovement;

    [Header("References")]

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private WallRunning wallRunning;

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

        if(playerInput._isWallrunning == true) 
        {
            movementSpeed = wallRunning.wallRunningSpeed;
        }
    }

    private void FixedUpdate()
    {
        if(_currentMovement.magnitude >= 1f) 
        {
            float targetAngle = Mathf.Atan2(_currentMovement.x, _currentMovement.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigidBody.velocity = moveDir * movementSpeed + Vector3.up * rigidBody.velocity.y;

            if (playerInput._isFalling == false)
            {
                playerInput._isWalkButtonPress = true;
            }

            if(playerInput._isFalling == true) 
            {
                playerInput._isWalkButtonPress = false;

                rigidBody.AddForce(Vector3.down * gravityModifier, ForceMode.Acceleration);
            }
        }

        else 
        {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);

            playerInput._isWalkButtonPress = false;
        }
    }

    public void Movement(InputValue value)
    {
        var movementInput = value.Get<Vector2>();
        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            playerInput._isFalling = false;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            playerInput._isFalling = true;
        }
    }
}