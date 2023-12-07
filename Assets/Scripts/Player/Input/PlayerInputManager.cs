using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the player inputs that are executed.
/// </summary>
public class PlayerInputManager : MonoBehaviour
{
    [Header("References")]

    private PlayerMovement playerMov;

    private PlayerLook playerLook;

    private WallRunning playerWallrun;

    private Running playerRunning;

    private Jumping playerJump;

    private CheatsManager cheatsManager;

    private PlayerInputs godModeAction;

    private PlayerInputs flashAction;

    private PlayerInputs featherFallAction;

    private FlyMovement playerFlyMovement;

    /// <summary>
    /// The action is assigned the UIInput.
    /// </summary>
    private void Awake()
    {
        godModeAction = new PlayerInputs();
        flashAction = new PlayerInputs();
        featherFallAction = new PlayerInputs();
    }


    /// <summary>
    /// Assign the components.
    /// </summary>
    private void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
        playerRunning = GetComponent<Running>();
        playerWallrun = GetComponent<WallRunning>();
        playerJump = GetComponent<Jumping>();
        playerLook = GetComponentInChildren<PlayerLook>();
        cheatsManager = GetComponent<CheatsManager>();
        playerFlyMovement = GetComponentInChildren<FlyMovement>();

        godModeAction.World.GodMode.performed += _ => IsGodMode();
        flashAction.World.Flash.performed += _ => IsFlash();
        featherFallAction.World.FeatherFall.performed += _ => IsFeatherFall();
    }

    /// <summary>
    /// Action is active.
    /// </summary>
    public void OnEnable()
    {
        godModeAction.Enable();
        flashAction.Enable();
        featherFallAction.Enable();
    }

    /// <summary>
    /// Action is disable.
    /// </summary>
    private void OnDisable()
    {
        godModeAction.Disable();
        flashAction.Disable();
        featherFallAction.Disable();
    }

    /// <summary>
    /// Functions are called to execute the jump mechanics.
    /// </summary>
    public void OnJump()
    {
        if(cheatsManager.featherFall == false) 
        {
            playerJump.JumpLogic();
        }

        if(playerWallrun.isWallrunning == true)
        {
            playerWallrun.WallJump();
        }
    }

    /// <summary>
    /// Functions are called to execute the movement mechanics.
    /// The movement function receives an input.
    /// </summary>
    /// <param name="value"></param>
    public void OnMove(InputValue value)
    {
        playerMov.Movement(value);
        playerWallrun.CheckForWall();
        playerWallrun.WallRunLogic();
    }

    /// <summary>
    /// Function are called to execute the run mechanic.
    /// </summary>
    public void OnSprintStart()
    {
        playerRunning.SprintStartLogic();   
    }

    /// <summary>
    /// Function are called to end the run mechanic.
    /// </summary>
    public void OnSprintFinish()
    {
        playerRunning.SprintFinishLogic();
    }

    /// <summary>
    /// Function are called to execute the camera look mechanic.
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnLook(InputValue inputValue)
    {
        playerLook.LookLogic(inputValue);
    }

    /// <summary>
    /// Load the next scene.
    /// </summary>
    public void OnNextLevel() 
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        SceneManager.LoadScene(nextScene);
    }

    /// <summary>
    /// Checks is the god mode is on or off.
    /// </summary>
    private void IsGodMode() 
    {
        if (cheatsManager.godMode == true) 
        {
            cheatsManager.GodModeDesactive();
        }
        
        else 
        {
            cheatsManager.GodModeActive();
        }
    }

    /// <summary>
    /// Chenks is the flash mode is on or off.
    /// </summary>
    private void IsFlash() 
    {
        if (cheatsManager.flash == true)
        {
            cheatsManager.FlashDesactive();
        }

        else
        {
            cheatsManager.FlashActive();
        }
    }

    /// <summary>
    /// Chenks is the feather fall mode is on or off.
    /// </summary>
    private void IsFeatherFall()
    {
        if (cheatsManager.featherFall == true)
        {
            cheatsManager.FeatherFallDesactive();
        }

        else
        {
            cheatsManager.FeatherFallActive();
        }
    }

    /// <summary>
    /// Move the player up when he is on cheat mode.
    /// </summary>
    public void OnUpMovementPress() 
    {
        if (cheatsManager.featherFall == true)
        {
            playerFlyMovement.GoUp = true;
        }
    }

    /// <summary>
    /// Stop moving the player Up.
    /// </summary>
    public void OnUpMovementRelease()
    {
        if (cheatsManager.featherFall == true)
        {
            playerFlyMovement.GoUp = false;
        }
    }

    /// <summary>
    /// Move the player down when he is on cheat mode.
    /// </summary>
    public void OnDownMovementPress() 
    {
        if (cheatsManager.featherFall == true)
        {
            playerFlyMovement.GoDown = true;
        }
    }

    /// <summary>
    /// Stop moving the player down.
    /// </summary>
    public void OnDownMovementRelease()
    {
        if (cheatsManager.featherFall == true)
        {
            playerFlyMovement.GoDown = false;
        }
    }
}