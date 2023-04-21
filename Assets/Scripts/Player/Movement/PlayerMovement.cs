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

    [SerializeField] private Climbing plClimbing;


    [Header("Movement")]
    
    [SerializeField] private float movementSpeed;

    private float normalSpeed;

    private float maxSpeed;

    public Vector3 _currentMovement;

    [SerializeField] private float SprintSpeed;

    [SerializeField] private float wallRunningSpeed;


    [Header("Input")]

    public bool _isWalkButtonPress;

    public bool _isSprintButtonPress;

    public bool _isJumpingButtonPress;

    public bool _isWallrunning;

    public bool _isFalling;

    public bool climbing;

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

        if(_isWallrunning == true) 
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

            if (_isFalling == false)
            {
                _isWalkButtonPress = true;
            }

            if(_isFalling == true) 
            {
                _isWalkButtonPress = false;
            }

            if (climbing == true) 
            {
                _isSprintButtonPress = false;
            }

            if(_isSprintButtonPress == true || _isFalling == true) 
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

            _isWalkButtonPress = false;
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
        if (_isWalkButtonPress == true)
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
        _isSprintButtonPress = true;
    }

    private void SprintReleased()
    {
        _isSprintButtonPress = false;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            _isFalling = false;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag("Ground"))
        {
            _isFalling = true;
        }
    }
}