using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallRunning : MonoBehaviour
{
    [Header("Wall Running")]

    [SerializeField] private LayerMask wallR;
    
    [SerializeField] private LayerMask ground;

    [SerializeField] private float wallRunForce;

    [SerializeField] private float wallJumpUpForce;

    [SerializeField] private float wallJumpSideForce;

    [SerializeField] private float wallClimbSpeed;

    [SerializeField] private float maxWallRunTime;

    private float wallRunTimer;


    [Header("Detection")]

    [SerializeField] private float wallCheckDistance;
    
    [SerializeField] private float minJumpHeight;

    private RaycastHit leftWallHit;

    private RaycastHit rightWallHit;

    public bool wallLeft;

    public bool wallRight;

   
    [Header("Exiting")]
    
    private bool exitingWall;

    [SerializeField] private float exitWallTime;

    private float exitWallTimer;

    
    [Header("Gravity")]

    [SerializeField] private bool useGravity;

    [SerializeField] private float gravityCounterForce;

    
    [Header("References")]

    public Transform orientation;

    public PlayerLook playerLook;

    private PlayerMovement playerMovement;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckForWall();
        WallRunLogic();
    }

    private void FixedUpdate()
    {
        if (playerMovement._isWallrunning == true)
        {
            WallRunnningMovement();
        }
    }
    public void CheckForWall() 
    {                               
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, wallR);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance, wallR);
    }

    private bool AboveGround() 
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, ground);
    }

    public void WallRunLogic() 
    {
        if ((wallLeft == true || wallRight == true) && playerMovement._currentMovement.z > 0 && AboveGround() && exitingWall == false)
        {
            if (playerMovement._isWallrunning == false)
            {
                StartWallRun();
            }

            if (wallRunTimer > 0)
            {
                wallRunTimer -= Time.deltaTime;
            }

            if (wallRunTimer <= 0 && playerMovement._isWallrunning == true)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }
        }

        else if (exitingWall == true) 
        {
            if (playerMovement._isWallrunning) 
            {
                StopWallRun();
            }

            if(exitWallTimer > 0) 
            {
                exitWallTimer -= Time.deltaTime;
            }

            if (exitWallTimer <= 0)
            {
                exitingWall = false;
            }
        }

    }
    public void StartWallRun() 
    {
        playerMovement._isWallrunning = true;
        playerMovement._isFalling = false;

        wallRunTimer = maxWallRunTime;

        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        if (wallLeft == true)
        {
            playerLook.DoTilt(-5f);
        }

        if (wallRight == true)
        {
            playerLook.DoTilt(5f);
        }
    }
    private void WallRunnningMovement()
    {
        playerRigidbody.useGravity = useGravity;

        Vector3 wallNormal = wallRight ? rightWallHit.normal  : leftWallHit.normal;

        Vector3 wallFoward = Vector3.Cross(wallNormal, transform.up);

        if ((orientation.forward - wallFoward).magnitude > (orientation.forward - -wallFoward).magnitude)
        {
            wallFoward = -wallFoward;
        }

        playerRigidbody.AddForce(wallFoward * wallRunForce, ForceMode.Force);

        if ((wallLeft == false && playerMovement._currentMovement.x > 0) && (wallRight == false && playerMovement._currentMovement.x < 0))
        {
            playerRigidbody.AddForce(-wallNormal * 100, ForceMode.Force);
        }

        if (useGravity == true) 
        {
            playerRigidbody.AddForce(transform.up * gravityCounterForce, ForceMode.Force);
        }
    }
    private void StopWallRun() 
    {
        playerMovement._isWallrunning = false;
    }

    public void WallJump() 
    {
        exitingWall = true;

        exitWallTimer = exitWallTime;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        playerRigidbody.AddForce(forceToApply, ForceMode.Impulse);
    }
}