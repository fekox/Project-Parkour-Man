using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Transform orientation;

    [SerializeField] private Rigidbody rb;

    [SerializeField]private PlayerMovement pm;

    [SerializeField] private LayerMask ClimbingWall;


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

        if (pm.climbing == true) 
        {
            ClimbingMovement();
        }
    }

    private void ClimbingLogic() 
    {
        if (wallFront == true && wallLookAngle < maxWallLookAngle)
        {
            if (pm.climbing == false && climbTimer > 0) 
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
            if (pm.climbing == true)
            {
                StopClimbing();
            }
        }
    }

    private void WallCheck() 
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRdius, orientation.forward, out frontWallHit, detectionLength, ClimbingWall);

        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            climbTimer = maxClimbTime;
        }
    }
}
