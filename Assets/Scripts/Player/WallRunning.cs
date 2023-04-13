using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    [Header("Wall Running")]

    public LayerMask whatIsWall;
    
    public LayerMask whatIsGround;

    public float wallRunForce;

    public float wallJumpUpForce;

    public float wallJumpSideForce;

    public float wallClimbSpeed;

    public float maxWallRunTime;

    private float wallRunTimer;

   
    [Header("Input")]

    public KeyCode jumpKey = KeyCode.Space;

    public KeyCode upwardsRunKey = KeyCode.LeftShift;

    private bool upwardsRunning;

    private float horizontalInput;
    
    private float verticalInput;

    
    [Header("Detection")]

    public float wallCheckDistance;
    
    public float minJumpHeight;

    private RaycastHit leftWallHit;

    private RaycastHit rightWallHit;

    private bool wallLeft;

    private bool wallRight;

   
    [Header("Exiting")]
    
    private bool exitingWall;

    public float exitWallTime;

    private float exitWallTimer;

    
    [Header("Gravity")]

    public bool useGravity;

    public float gravityCounterForce;

    
    [Header("References")]

    public Transform orientation;

    public PlayerLook cam;

    private PlayerMovement pm;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckForWall();
        StateMachine();
    }

    private void FixedUpdate()
    {
        if (pm._isWallRunning == true)
        {
            WallRunnningMovement();
        }
    }
    private void CheckForWall() 
    {                               //Start point        //Direction       //Store hit info      //Distance
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, whatIsWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance, whatIsWall);
    }

    private bool AboveGround() 
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
    }

    private void StateMachine() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        upwardsRunning = Input.GetKey(upwardsRunKey);

        //Wallrunnig
        if((wallLeft || wallRight) && verticalInput > 0 && AboveGround() && !exitingWall) 
        {
            if (!pm._isWallRunning)
            {
                StartWallRun();
            }

            if (wallRunTimer > 0) 
            {
                wallRunTimer -= Time.deltaTime;
            }

            if(wallRunTimer <= 0 && pm._isWallRunning) 
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }

            if (Input.GetKeyDown(jumpKey))
            {
                WallJump();
            }
        }

        //Exiting
        else if (exitingWall) 
        {
            if (pm._isWallRunning) 
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
    private void StartWallRun() 
    {
        pm._isWallRunning = true;

        wallRunTimer = maxWallRunTime;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //cam.DoFov(90f);

        if (wallLeft) 
        {
            cam.DoTilt(-10f);
        }

        if (wallRight)
        {
            cam.DoTilt(10f);
        }
    }
    private void WallRunnningMovement()
    {
        rb.useGravity = useGravity;

        Vector3 wallNormal = wallRight ? rightWallHit.normal  : leftWallHit.normal;

        Vector3 wallFoward = Vector3.Cross(wallNormal, transform.up);

        if ((orientation.forward - wallFoward).magnitude > (orientation.forward - -wallFoward).magnitude)
        {
            wallFoward = -wallFoward;
        }

        rb.AddForce(wallFoward * wallRunForce, ForceMode.Force);

        if (upwardsRunning) 
        {
            rb.velocity = new Vector3(rb.velocity.x, wallClimbSpeed, rb.velocity.z);
        }

        if (!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0)) 
        {
            rb.AddForce(-wallNormal * 100, ForceMode.Force);
        }

        if (useGravity) 
        {
            rb.AddForce(transform.up * gravityCounterForce, ForceMode.Force);
        }
    }
    private void StopWallRun() 
    {
        pm._isWallRunning = false;

        cam.DoFov(80f);
        cam.DoTilt(0f);
    }

    private void WallJump() 
    {
        exitingWall = true;

        exitWallTimer = exitWallTime;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(forceToApply, ForceMode.Impulse);
    }
}