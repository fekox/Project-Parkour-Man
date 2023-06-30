using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Transform orientation;

    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private LayerMask climbingWall;


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

    private void Update()
    {
        WallCheck();
        ClimbingLogic();

        //TODO: Fix - Should be event based
        if (playerInput.climbing == true) 
        {
            ClimbingMovement();
        }
    }

    private void ClimbingLogic() 
    {
        if (wallFront == true && wallLookAngle < maxWallLookAngle)
        {
            //TODO: Fix - Should be event based
            if (playerInput.climbing == false && climbTimer > 0) 
            {
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
            if (playerInput.climbing == true || playerInput._isFalling == false)
            {
                StopClimbing();
            }
        }
    }

    private void WallCheck() 
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRdius, orientation.forward, out frontWallHit, detectionLength, climbingWall);

        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
    }

    private void StartClimbing() 
    {
        playerInput.climbing = true;
        playerInput._isFalling = false;
    }

    private void ClimbingMovement() 
    {
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, climbSpeed, playerRigidbody.velocity.z);       
    }

    private void StopClimbing() 
    {
        playerInput.climbing = false;
    }

    private void OnTriggerEnter(Collider player)
    {
        //TODO: Fix - Hardcoded value
        if (player.gameObject.CompareTag("Ground"))
        {
            climbTimer = maxClimbTime;
        }
    }
}