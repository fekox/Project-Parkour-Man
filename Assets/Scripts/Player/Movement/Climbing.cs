using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the player's scaling mechanics.
/// </summary>
public class Climbing : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Transform orientation;

    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private LayerMask climbingWall;

    [SerializeField] private string groundTagName;

    public event Action<bool> onClimbChange;

    [Header("Climbing")]

    [SerializeField] private float climbSpeed;

    [SerializeField] private float maxClimbTime;

    private float climbTimer;

    [Header("Detection")]

    [SerializeField] private float detectionLength;

    [SerializeField] private float sphereCastRdius;

    [SerializeField] private float maxWallLookAngle;

    private float wallLookAngle;

    private RaycastHit frontWallHit;

    private bool wallFront;

    public bool isClimbing;

    /// <summary>
    /// Calls functions that check the player's distance from the wall, 
    /// the scaling logic, and movement while the player climbs.
    /// </summary>
    private void Update()
    {
        WallCheck();
        ClimbingLogic();

        if (isClimbing == true) 
        {
            ClimbingMovement();
        }
    }

    /// <summary>
    /// Execute wall climbing logic.
    /// </summary>
    private void ClimbingLogic() 
    {
        if (wallFront == true && wallLookAngle < maxWallLookAngle)
        {
            if (isClimbing == false && climbTimer > 0) 
            {
                onClimbChange?.Invoke(true);
                StartClimbing();       
            }

            if (climbTimer > 0)
            {
                climbTimer -= Time.deltaTime;
            }

            if (climbTimer < 0) 
            {
                StopClimbing();            
            }
        }

        else
        {
            if (isClimbing == true || playerMovement.isFalling == false)
            {
                StopClimbing();
            }
        }
    }

    /// <summary>
    /// Check if the player has a wall in front of him.
    /// </summary>
    private void WallCheck() 
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRdius, orientation.forward, out frontWallHit, detectionLength, climbingWall);

        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
    }

    /// <summary>
    /// The boolean is set to true so that the player starts to scale.
    /// </summary>
    private void StartClimbing() 
    {
        isClimbing = true;
        playerMovement.isFalling = false;
    }

    /// <summary>
    /// Make the algorithm so that the player starts to scale.
    /// </summary>
    private void ClimbingMovement() 
    {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, climbSpeed, playerRigidbody.velocity.z);       
    }

    /// <summary>
    /// The boolean is set to false and the climbing animation stoped.
    /// </summary>
    private void StopClimbing() 
    {
        onClimbChange?.Invoke(false);
        isClimbing = false;
    }

    /// <summary>
    /// When the player collides with the object the scaling time is reset.
    /// </summary>
    /// <param name="player"></param>
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag(groundTagName))
        {
            climbTimer = maxClimbTime;
        }
    }
}