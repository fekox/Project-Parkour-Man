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
    }
}
