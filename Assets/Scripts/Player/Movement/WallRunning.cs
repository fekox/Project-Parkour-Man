using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Manages the player's wall running mechanics.
/// </summary>
public class WallRunning : MonoBehaviour
{
    [Header("Wall Running")]

    [SerializeField] private LayerMask wallR;
    
    [SerializeField] private LayerMask ground;

    [SerializeField] private float wallRunForce;

    [SerializeField] private float wallJumpUpForce;

    [SerializeField] private float wallJumpSideForce;

    [SerializeField] private float maxWallRunTime;

    private float wallRunTimer;

    private Vector3 forceToApply;

    private Vector3 wallNormal;

    public bool isWallrunning;

    public float wallRunningSpeed;


    [Header("Detection")]

    [SerializeField] private float wallCheckDistance;
    
    [SerializeField] private float minJumpHeight;

    private RaycastHit leftWallHit;

    private RaycastHit rightWallHit;

    public bool wallLeft;

    public bool wallRight;

   
    [Header("Exiting")]

    [SerializeField] private float exitWallTime;

    private bool exitingWall;

    private float exitWallTimer;

    
    [Header("Gravity")]

    [SerializeField] private bool useGravity;

    [SerializeField] private float gravityCounterForce;

    
    [Header("References")]

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private int cameraTiltLeft;
    
    [SerializeField] private int cameraTilRight;

    private Rigidbody playerRigidbody;

    public Transform orientation;

    public PlayerLook playerLook;

    /// <summary>
    /// The rigid body component is set. 
    /// Player movement speed has been set.
    /// </summary>
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        if (isWallrunning == true)
        {
           playerMovement.movementSpeed = wallRunningSpeed;
        }
    }

    /// <summary>
    /// Logic is executed check the walls and run along the wall.
    /// </summary>
    private void Update()
    {
        CheckForWall();
        WallRunLogic();
    }

    /// <summary>
    /// If the player is running along the wall, the wall movement logic is executed.
    /// </summary>
    private void FixedUpdate()
    {
        if (isWallrunning == true)
        {
            WallRunnningMovement();
        }
    }

    /// <summary>
    /// Check if the player has a wall to the right and if the 
    /// player has a wall to the right using a raycast.
    /// </summary>
    public void CheckForWall() 
    {                               
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, wallCheckDistance, wallR);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, wallCheckDistance, wallR);
    }

    /// <summary>
    /// Returns a raycast to find out if the player is on the ground or not.
    /// </summary>
    /// <returns></returns>
    private bool AboveGround() 
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, ground);
    }

    /// <summary>
    /// Wall logic is executed.
    /// </summary>
    public void WallRunLogic() 
    {
        if ((wallLeft == true || wallRight == true) && playerMovement._currentMovement.z > 0 && AboveGround() && exitingWall == false)
        {
            if (isWallrunning == false)
            {
                StartWallRun();
            }

            if (wallRunTimer > 0)
            {
                wallRunTimer -= Time.deltaTime;
            }

            if (wallRunTimer <= 0 && isWallrunning == true)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }
        }

        else if (exitingWall == true) 
        {
            if (isWallrunning) 
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

    /// <summary>
    /// The wall run algorithm is executed.
    /// </summary>
    public void StartWallRun() 
    {
        isWallrunning = true;
        playerMovement.isFalling = false;

        wallRunTimer = maxWallRunTime;

        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        if (wallLeft == true)
        {
            playerLook.DoTilt(cameraTiltLeft);
        }

        if (wallRight == true)
        {
            playerLook.DoTilt(cameraTilRight);
        }
    }

    /// <summary>
    /// The wall movement algorithm was executed.
    /// </summary>
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

    /// <summary>
    /// The wall execution bool is set to false.
    /// </summary>
    private void StopWallRun() 
    {
        isWallrunning = false;
    }

    /// <summary>
    /// The wall-to-wall hopping algorithm is executed.
    /// </summary>
    public void WallJump() 
    {
        exitingWall = true;

        exitWallTimer = exitWallTime;

        wallNormal = wallRight ? rightWallHit.normal : leftWallHit.normal;

        forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        playerRigidbody.AddForce(forceToApply, ForceMode.Impulse);
    }
}