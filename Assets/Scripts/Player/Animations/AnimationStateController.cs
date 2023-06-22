using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [Header("Setup")]
    
    [SerializeField] private Animator animator;

    [Header("References")]

    [SerializeField] private PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Walking

        if (playerMovement._isWalkButtonPress == true) 
        {
            animator.SetBool("IsWalking", true);
        }

        if (playerMovement._isWalkButtonPress == false)
        {
            animator.SetBool("IsWalking", false);
        }

        //Running

        if (playerMovement._isWalkButtonPress == true && playerMovement._isSprintButtonPress == true) 
        {
            animator.SetBool("IsRunning", true);
        }

        if (playerMovement._isSprintButtonPress == false)
        {
            animator.SetBool("IsRunning", false);
        }

        //Jumping

        if (playerMovement._isJumpingButtonPress == true)
        {
            animator.SetBool("IsJumping", true);
        }

        if (playerMovement._isJumpingButtonPress == false)
        {
            animator.SetBool("IsJumping", false);
        }

        //Falling

        if (playerMovement._isFalling == true) 
        {
            animator.SetBool("IsFalling", true);
        }

        if (playerMovement._isFalling == false)
        {
            animator.SetBool("IsFalling", false);
        }

        //Climbing

        if (playerMovement.climbing == true)
        {
            animator.SetBool("IsClimbing", true);
        }

        if (playerMovement.climbing == false)
        {
            animator.SetBool("IsClimbing", false);
        }
    }
}