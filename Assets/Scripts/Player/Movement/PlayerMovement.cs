using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// Manages the player's movement mechanics.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Setup")]
    
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform playerCamera;

    public bool isFalling;


    [Header("Movement")]

    [SerializeField] private float gravityModifier;

    private float normalMovementSpeed;

    private float maxMovementSpeed;

    public float movementSpeed;

    public Vector3 _currentMovement;

    [Header("References")]

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private WallRunning wallRunning;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private string groundTagName;

    [SerializeField] private CheatsManager cheatsManager;

    public event Action<bool> onWalkMovementChange;

    /// <summary>
    /// The component is added to the rigibody.
    /// </summary>
    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    /// <summary>
    /// The movement speed of the player is set.
    /// </summary>
    private void Start()
    {
        int auxNumber = 3;

        normalMovementSpeed = movementSpeed;
        maxMovementSpeed = movementSpeed * auxNumber;

        if (!rigidBody)
        {
            enabled = false;
        }
    }

    /// <summary>
    /// The algorithm for the movement of the player to follow 
    /// the camera is executed.
    /// </summary>
    private void FixedUpdate()
    {
        if(_currentMovement.magnitude >= 1f) 
        {
            float targetAngle = Mathf.Atan2(_currentMovement.x, _currentMovement.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigidBody.velocity = moveDir * movementSpeed + Vector3.up * rigidBody.velocity.y;

            onWalkMovementChange?.Invoke(!playerMovement.isFalling);
            
            if(playerMovement.isFalling == true) 
            {
                rigidBody.AddForce(Vector3.down * gravityModifier, ForceMode.Acceleration);
            }
        }

        else 
        {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);

            onWalkMovementChange?.Invoke(false);
        }
    }

    /// <summary>
    /// Sets the player movemente speed depending if flash cheat is active or not. 
    /// </summary>
    private void Update()
    {
        if (cheatsManager.flash == true) 
        {
            SetMovementSpeed(maxMovementSpeed);
        }
    }

    /// <summary>
    /// The player movement algorithm is executed.
    /// </summary>
    /// <param name="value"></param>
    public void Movement(InputValue value)
    {
        var movementInput = value.Get<Vector2>();
        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    /// <summary>
    /// When the player collides with the ground, the 
    /// boolean player falling is set to false.
    /// </summary>
    /// <param name="player"></param>
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag(groundTagName))
        {
            playerMovement.isFalling = false;
        }
    }

    /// <summary>
    /// When the player stops colliding with the ground, the 
    /// boolean player drop is set to true.
    /// </summary>
    /// <param name="player"></param>
    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag(groundTagName))
        {
            playerMovement.isFalling = true;
        }
    }

    /// <summary>
    /// Sets player speed.
    /// </summary>
    /// <param name="newSpeed"></param>
    private void SetMovementSpeed(float newSpeed) 
    {
        movementSpeed = newSpeed;
    }
}