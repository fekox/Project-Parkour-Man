using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]

    public Transform orientation;

    public Rigidbody rb;

    public PlayerMovement pm;

    public LayerMask ClimbingWall;


    [Header("Climbing")]

    public float climbSpeed;

    public float maxClimbTime;

    private float climbTimer;

    [Header("Detection")]

    public float detectionLength;

    public float sphereCastRdius;

    public float maxWallLookAngle;

    private float wallLookAngle;

    private RaycastHit frontWallHit;

    private bool wallFront;

    private void Update()
    {
        WallCheck();
        ClimbingLogic();

        if (pm.climbing) 
        {
            ClimbingMovement();
        }
    }

    private void ClimbingLogic() 
    {
        if (wallFront && wallLookAngle < maxWallLookAngle)
        {
            if (!pm.climbing && climbTimer > 0) 
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
            if (pm.climbing)
            {
                StopClimbing();
            }
        }
    }

    private void WallCheck() 
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRdius, orientation.forward, out frontWallHit, detectionLength, ClimbingWall);

        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);

        climbTimer = maxClimbTime;
    }

    private void StartClimbing() 
    {
        pm.climbing = true;
    }

    private void ClimbingMovement() 
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);       
    }

    private void StopClimbing() 
    {
        pm.climbing = false;
    }

}
