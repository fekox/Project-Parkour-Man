using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WallRunning : MonoBehaviour
{
    [Header("Wall Running")]

    public float wallRunningSpeed;

    [SerializeField] private LayerMask wallR;
    
    [SerializeField] private LayerMask ground;

    [SerializeField] private float wallRunForce;

    [SerializeField] private float wallJumpUpForce;

    [SerializeField] private float wallJumpSideForce;

    //TODO: TP2 - Remove unused methods/variables/classes
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
    
    //TODO: TP2 - Syntax - Fix declaration order
    private bool exitingWall;

    [SerializeField] private float exitWallTime;

    private float exitWallTimer;

    
    [Header("Gravity")]

    [SerializeField] private bool useGravity;

    [SerializeField] private float gravityCounterForce;

    
    [Header("References")]

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private PlayerMovement playerMovement;

    //TODO: TP2 - Syntax - Fix declaration order
    public Transform orientation;

    public PlayerLook playerLook;

    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        if (playerInput._isWallrunning == true)
        {
           playerMovement.movementSpeed = wallRunningSpeed;
        }
    }

    private void Update()
    {
        CheckForWall();
        WallRunLogic();
    }

    private void FixedUpdate()
    {
        if (playerInput._isWallrunning == true)
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
            //TODO: TP2 - SOLID
            //TODO: TP2 - FSM
            if (playerInput._isWallrunning == false)
            {
                StartWallRun();
            }

            if (wallRunTimer > 0)
            {
                wallRunTimer -= Time.deltaTime;
            }

            if (wallRunTimer <= 0 && playerInput._isWallrunning == true)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }
        }

        else if (exitingWall == true) 
        {
            if (playerInput._isWallrunning) 
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
        playerInput._isWallrunning = true;
        playerInput._isFalling = false;

        wallRunTimer = maxWallRunTime;

        //TODO: Fix - Should be in FixedUpdate
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        if (wallLeft == true)
        {
            //TODO: Fix - Hardcoded value
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
    //TODO: TP2 - FSM
    private void StopWallRun() 
    {
        playerInput._isWallrunning = false;
    }

    public void WallJump() 
    {
        exitingWall = true;

        exitWallTimer = exitWallTime;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        //TODO: Fix - Should be on fixedUpdate
        playerRigidbody.AddForce(forceToApply, ForceMode.Impulse);
    }
}