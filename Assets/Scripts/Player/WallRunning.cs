using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    [Header("Wall Running")]

    public LayerMask whatIsWall;
    
    public LayerMask whatIsGround;

    public float wallRunForce;

    public float wallClimbSpeed;

    public float maxWallRunTime;

    private float wallRunTimer;

    [Header("Input")]

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

    [Header("References")]

    public Transform orientation;

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

        else 
        {
            rb.useGravity = true;
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
        if((wallLeft || wallRight) && verticalInput > 0 && AboveGround()) 
        {
            if (pm._isWallRunning == false) 
            {
                StartWallRun();
            }

            else
            {
                if (pm._isWallRunning == true) 
                {
                    StopWallRun();
                }
            }
        }
    }

    private void StartWallRun() 
    {
        pm._isWallRunning = true;
    }

    private void WallRunnningMovement()
    {
        rb.useGravity = false;
       
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

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

        pm._isWallRunning = false;
    }

    private void StopWallRun() 
    {
        pm._isWallRunning = false;
    }

}
