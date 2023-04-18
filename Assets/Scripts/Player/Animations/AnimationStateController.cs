using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [Header("Setup")]
    
    [SerializeField] private Animator animator;

    [Header("References")]

    [SerializeField] private PlayerMovement pm;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (pm._isWalkButtonPress == true) 
        {
            animator.SetBool("IsWalking", true);
        }

        if (pm._isWalkButtonPress == false)
        {
            animator.SetBool("IsWalking", false);
        }

        if (pm._isWalkButtonPress == true && pm._isSprintButtonPress == true) 
        {
            animator.SetBool("IsRunning", true);
        }

        if (pm._isSprintButtonPress == false)
        {
            animator.SetBool("IsRunning", false);
        }

        if (pm._isJumpingButtonPress == true)
        {
            animator.SetBool("IsJumping", true);
        }

        if (pm._isJumpingButtonPress == false)
        {
            animator.SetBool("IsJumping", false);
        }

        if (pm.climbing == true)
        {
            animator.SetBool("IsClimbing", true);
        }

        if (pm.climbing == false)
        {
            animator.SetBool("IsClimbing", false);
        }
    }
}
