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

    private bool wallLeft;

    private bool wallRight;

   
    [Header("Exiting")]
    
    private bool exitingWall;

    [SerializeField] private float exitWallTime;

    private float exitWallTimer;

    
    [Header("Gravity")]

    [SerializeField] private bool useGravity;

    [SerializeField] private float gravityCounterForce;

    
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
        WallRunLogic();
    }

    private void FixedUpdate()
    {
        if (pm._isWallRunning == true)
        {
            WallRunnningMovement();
        }
    }
    public void CheckForWall() 
    {                               //Start point        //Direction       //Store hit info      //Distance
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, wallR);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance, wallR);
    }

    private bool AboveGround() 
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, ground);
    }

    public void WallRunLogic() 
    {
        //Wallrunnig
        if ((wallLeft == true || wallRight == true) && pm._currentMovement.z > 0 && AboveGround() && exitingWall == false)
        {
            if (pm._isWallRunning == false)
            {
                StartWallRun();
            }

            if (wallRunTimer > 0)
            {
                wallRunTimer -= Time.deltaTime;
            }

            if (wallRunTimer <= 0 && pm._isWallRunning == true)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }
        }

        //Exiting
        else if (exitingWall == true) 
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
    public void StartWallRun() 
    {
        pm._isWallRunning = true;

        wallRunTimer = maxWallRunTime;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (wallLeft == true)
        {
            cam.DoTilt(-5f);
        }

        if (wallRight == true)
        {
            cam.DoTilt(5f);
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

        if ((wallLeft == false && pm._currentMovement.x > 0) && (wallRight == false && pm._currentMovement.x < 0))
        {
            rb.AddForce(-wallNormal * 100, ForceMode.Force);
        }

        if (useGravity == true) 
        {
            rb.AddForce(transform.up * gravityCounterForce, ForceMode.Force);
        }
    }
    private void StopWallRun() 
    {
        pm._isWallRunning = false;
    }

    public void WallJump() 
    {
        exitingWall = true;

        exitWallTimer = exitWallTime;

        Vector3 wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(forceToApply, ForceMode.Impulse);
    }
}