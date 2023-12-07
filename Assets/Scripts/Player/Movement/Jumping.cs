using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the player's jumping mechanic.
/// </summary>
public class Jumping : MonoBehaviour
{
    private const int maxFloorDistance = 10;

    
    [Header("Setup")]

    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform feetPivot;

    
    [Header("Movement")]

    [SerializeField] private float jumpForce = 6f;

    [SerializeField] private float minJumpDistance = 0.25f;

    [SerializeField] private float jumpBufferTime = 0.25f;

    [SerializeField] private float coyoteTime = 0.2f;

    [SerializeField] private float maxJumpAnimation = 0.5f;

    private float maxJumpForce;
    private float normalJumpForce;

    private Coroutine _jumpCoroutine;

    private float jumpAnimationTimer;


    [Header("References")]

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private PlayerInputManager playerInput;

    [SerializeField] private string sfxName;

    [SerializeField] private CheatsManager cheatsManager;

    public bool isJumping;

    public event Action<bool> onJumpChange;

    [Header("Sounds")]

    [SerializeField] private SoundsPlayer soundsPlayer;

    /// <summary>
    /// The component is assigned to the rigidbody.
    /// </summary>
    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Jump time is set.
    /// </summary>
    void Start()
    {
        int auxNumber = 3;

        normalJumpForce = jumpForce;
        maxJumpForce = jumpForce * auxNumber;

        if (!rigidBody)
        {
            enabled = false;
        }

        jumpAnimationTimer = maxJumpAnimation;
    }

    /// <summary>
    /// If the coroutine is null it stops, otherwise the jump coroutine is executed.
    /// Jump animation is played.
    /// </summary>
    public void JumpLogic()
    {
        if (_jumpCoroutine != null)
        {
            StopCoroutine(_jumpCoroutine);
        }

        _jumpCoroutine = StartCoroutine(JumpCoroutine());
        isJumping = true;

        onJumpChange?.Invoke(true);
        soundsPlayer.PlaySFX(sfxName);
    }

    /// <summary>
    /// If the character is jumping, start the jumping animation timer.
    /// If the animation time is less than 0, the character stops jumping 
    /// and the jumping animation stops.
    /// </summary>
    private void Update()
    {
        if (isJumping == true) 
        {
            jumpAnimationTimer -= Time.deltaTime;
        }

        if(jumpAnimationTimer <= 0) 
        {
            isJumping = false;
            jumpAnimationTimer = maxJumpAnimation;
            onJumpChange?.Invoke(false);
        }

        CheckJumpForce();
    }

    /// <summary>
    /// The coroutine jump logic will be executed.
    /// </summary>
    /// <returns></returns>
    private IEnumerator JumpCoroutine()
    {
        if (!feetPivot)
        {
            yield break;
        }

        for (var timeElapsed = 0.0f; timeElapsed <= jumpBufferTime; timeElapsed += Time.fixedDeltaTime)
        {
            yield return new WaitForFixedUpdate();

            var isFalling = rigidBody.velocity.y <= 0;
            var currentFeetPosition = feetPivot.position;

            var canNormalJump = isFalling && CanJumpInPosition(currentFeetPosition);

            var coyoteTimeFeetPosition = currentFeetPosition - rigidBody.velocity * coyoteTime;
            var canCoyoteJump = isFalling && CanJumpInPosition(coyoteTimeFeetPosition);

            if (!canNormalJump && canCoyoteJump)
            {
                Debug.DrawLine(currentFeetPosition, coyoteTimeFeetPosition, Color.green, 5f);
            }

            if (canNormalJump || canCoyoteJump)
            {
                var jumpForceVector = Vector3.up * jumpForce;

                if (rigidBody.velocity.y < 0)
                    jumpForceVector.y -= rigidBody.velocity.y;

                rigidBody.AddForce(jumpForceVector, ForceMode.Impulse);

                yield break;
            }
        }
    }

    /// <summary>
    /// Returns a raycast that is at the position of the player's feet to detect 
    /// if the player can jump again or not
    /// </summary>
    /// <param name="currentFeetPosition"></param>
    /// <returns></returns>
    private bool CanJumpInPosition(Vector3 currentFeetPosition)
    {
        return Physics.Raycast(currentFeetPosition, Vector3.down, out var hit, maxFloorDistance)
               && hit.distance <= minJumpDistance;
    }

    /// <summary>
    /// Draw the raycast that is at the player's feet.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (!feetPivot)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(feetPivot.position, feetPivot.position + Vector3.down * minJumpDistance);
    }

    /// <summary>
    /// Sets the jump force depending on whether the flash cheat is on or off.
    /// </summary>
    private void CheckJumpForce() 
    {
        if (cheatsManager.flash == true)
        {
            SetJumpForce(maxJumpForce);
        }

        if (cheatsManager.flash == false)
        {
            SetJumpForce(normalJumpForce);
        }
    }

    /// <summary>
    /// Sets jump force.
    /// </summary>
    /// <param name="newForce"></param>
    private void SetJumpForce(float newForce) 
    {
        jumpForce = newForce;
    }
}