using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [Header("Setup")]
    
    [SerializeField] private Animator animator;

    [Header("References")]

    [SerializeField] private PlayerInputManager playerInput;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Walking

        //TODO: Fix - Should be event based
        if (playerInput._isWalkButtonPress == true) 
        {
            animator.SetBool("IsWalking", true);
        }

        if (playerInput._isWalkButtonPress == false)
        {
            animator.SetBool("IsWalking", false);
        }

        //Running

        if (playerInput._isWalkButtonPress == true && playerInput._isSprintButtonPress == true) 
        {
            animator.SetBool("IsRunning", true);
        }

        if (playerInput._isSprintButtonPress == false)
        {
            animator.SetBool("IsRunning", false);
        }

        //Jumping

        if (playerInput._isJumpingButtonPress == true)
        {
            animator.SetBool("IsJumping", true);
        }

        if (playerInput._isJumpingButtonPress == false)
        {
            animator.SetBool("IsJumping", false);
        }

        //Falling

        if (playerInput._isFalling == true) 
        {
            animator.SetBool("IsFalling", true);
        }

        if (playerInput._isFalling == false)
        {
            animator.SetBool("IsFalling", false);
        }

        //Climbing

        if (playerInput.climbing == true)
        {
            animator.SetBool("IsClimbing", true);
        }

        if (playerInput.climbing == false)
        {
            animator.SetBool("IsClimbing", false);
        }
    }
}