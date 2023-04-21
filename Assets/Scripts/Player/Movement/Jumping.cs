using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private const int MaxFloorDistance = 10;

    
    [Header("Setup")]

    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform feetPivot;

    
    [Header("Movement")]

    [SerializeField] private float jumpForce = 6f;

    [SerializeField] private float minJumpDistance = 0.25f;

    [SerializeField] private float jumpBufferTime = 0.25f;

    [SerializeField] private float coyoteTime = 0.2f;

    private Coroutine _jumpCoroutine;

    [SerializeField] private float maxJumpAnimation = 0.5f;

    private float jumpAnimationTimer;



    [Header("References")]

    private PlayerMovement pm;


    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (!rigidBody)
        {
            enabled = false;
        }

        pm = GetComponent<PlayerMovement>();

        jumpAnimationTimer = maxJumpAnimation;
    }

    public void JumpLogic()
    {
        if (_jumpCoroutine != null)
        {
            StopCoroutine(_jumpCoroutine);
        }

        _jumpCoroutine = StartCoroutine(JumpCoroutine());
        pm._isJumpingButtonPress = true;
    }

    private void Update()
    {
        if (pm._isJumpingButtonPress == true) 
        {
            jumpAnimationTimer -= Time.deltaTime;

            Debug.Log(jumpAnimationTimer);
        }

        if(jumpAnimationTimer <= 0) 
        {
            pm._isJumpingButtonPress = false;
            jumpAnimationTimer = maxJumpAnimation;
        }
    }

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

    private bool CanJumpInPosition(Vector3 currentFeetPosition)
    {
        return Physics.Raycast(currentFeetPosition, Vector3.down, out var hit, MaxFloorDistance)
               && hit.distance <= minJumpDistance;
    }

    private void OnDrawGizmosSelected()
    {
        if (!feetPivot)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(feetPivot.position, feetPivot.position + Vector3.down * minJumpDistance);
    }
}
