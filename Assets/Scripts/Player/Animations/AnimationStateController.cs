using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Control which player animations are played.
/// </summary>
public class AnimationStateController : MonoBehaviour
{
    [Header("Setup")]
    
    [SerializeField] private Animator animator;

    [Header("References")]

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Running playerRunning;

    [SerializeField] private Jumping playerJumping;

    [SerializeField] private Climbing playerClimbing;


    /// <summary>
    /// Assign the component to the animator.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// The falling animation is activated and deactivated.
    /// </summary>
    void Update()
    {
        if (playerMovement.isFalling == true) 
        {
            animator.SetBool("IsFalling", true);
        }

        if (playerMovement.isFalling == false)
        {
            animator.SetBool("IsFalling", false);
        }
    }

    /// <summary>
    /// Enable events.
    /// </summary>
    private void OnEnable()
    {
        playerMovement.onWalkMovementChange += HandleMovementChange;
        playerRunning.onRunChange += HandleRunningChange;
        playerJumping.onJumpChange += HandleJumpingChange;
        playerClimbing.onClimbChange += HandleClimbingChange;
    }

    /// <summary>
    /// Turn the walking animation on or off.
    /// </summary>
    /// <param name="isWalking"></param>
    private void HandleMovementChange(bool isWalking) 
    {
        animator.SetBool("IsWalking", isWalking);
    }

    /// <summary>
    /// Turn the running animation on or off.
    /// </summary>
    /// <param name="isRunning"></param>
    private void HandleRunningChange(bool isRunning) 
    {
        animator.SetBool("IsRunning", isRunning);
    }

    /// <summary>
    /// Turn the jumping animation on or off.
    /// </summary>
    /// <param name="isJumping"></param>
    private void HandleJumpingChange(bool isJumping) 
    {
        animator.SetBool("IsJumping", isJumping);
    }

    /// <summary>
    /// Turn the climbing animation on or off.
    /// </summary>
    /// <param name="isClimbing"></param>
    private void HandleClimbingChange(bool isClimbing)
    {
        animator.SetBool("IsClimbing", isClimbing);
    }

    /// <summary>
    ///  Disable events.
    /// </summary>
    private void OnDisable()
    {
        playerMovement.onWalkMovementChange -= HandleMovementChange;
        playerRunning.onRunChange -= HandleRunningChange;
        playerJumping.onJumpChange -= HandleJumpingChange;
        playerClimbing.onClimbChange -= HandleClimbingChange;
    }
}