using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [Header("Setup")]
    
    [SerializeField] private Animator animator;

    [Header("References")]

    [SerializeField] private PlayerMovement pm;

    [SerializeField] private WallRunning wl;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Walking

        if (pm._isWalkButtonPress == true) 
        {
            animator.SetBool("IsWalking", true);
        }

        if (pm._isWalkButtonPress == false)
        {
            animator.SetBool("IsWalking", false);
        }

        //Running

        if (pm._isWalkButtonPress == true && pm._isSprintButtonPress == true) 
        {
            animator.SetBool("IsRunning", true);
        }

        if (pm._isSprintButtonPress == false)
        {
            animator.SetBool("IsRunning", false);
        }

        //Jumping

        if (pm._isJumpingButtonPress == true)
        {
            animator.SetBool("IsJumping", true);
        }

        if (pm._isJumpingButtonPress == false)
        {
            animator.SetBool("IsJumping", false);
        }

        //Climbing

        if (pm.climbing == true)
        {
            animator.SetBool("IsClimbing", true);
        }

        if (pm.climbing == false)
        {
            animator.SetBool("IsClimbing", false);
        }

        ////Wallrunning Left

        //if (pm._isWallRunButtonPress == true && wl.wallLeft == true) 
        //{
        //    animator.SetBool("IsWallrunningLeft", true);
        //}

        //if (pm._isWallRunButtonPress == false && wl.wallLeft == false)
        //{
        //    animator.SetBool("IsWallrunningLeft", false);
        //}

        ////Wallrunning Right

        //if (pm._isWallRunButtonPress == true && wl.wallRight == true)
        //{
        //    animator.SetBool("IsWallrunningRight", true);
        //}

        //if (pm._isWallRunButtonPress == false && wl.wallRight == false)
        //{
        //    animator.SetBool("IsWallrunningRight", false);
        //}

    }
}
