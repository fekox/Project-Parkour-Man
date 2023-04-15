
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private const int MaxFloorDistance = 10;

    [Header("Setup")]
    
    [SerializeField] private Rigidbody rigidBody;

    [SerializeField] private Transform feetPivot;

    [SerializeField] private Transform playerCamera;

    [Header("Movement")]
    
    [SerializeField] private float movementSpeed;

    [SerializeField] private float coyoteTime = 0.2f;

    private float normalSpeed;

    private float maxSpeed;

    private Vector3 _currentMovement;

    [SerializeField] private float SprintSpeed;

    [SerializeField] private float jumpForce = 10f;

    [SerializeField] private float minJumpDistance = 0.25f;

    [SerializeField] private float jumpBufferTime = 0.25f;

    private Coroutine _jumpCoroutine;

    [SerializeField] private float wallRunningSpeed;

    [SerializeField] private bool _isSprinting;

    public bool _isWallRunning;

    public bool _isGrounded;
    
    private void OnValidate()
    {
        rigidBody ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (!rigidBody)
        {
            enabled = false;
        }

        normalSpeed = movementSpeed;

        maxSpeed = normalSpeed + movementSpeed;

        movementSpeed = wallRunningSpeed;
    }
    private void FixedUpdate()
    {
        if(_currentMovement.magnitude >= 1f) 
        {
            float targetAngle = Mathf.Atan2(_currentMovement.x, _currentMovement.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rigidBody.velocity = moveDir * movementSpeed + Vector3.up * rigidBody.velocity.y;

            if(_isSprinting == true) 
            {
                movementSpeed = SprintSpeed;

                if(movementSpeed > maxSpeed) 
                {
                    movementSpeed = normalSpeed;
                }
            }

            else 
            {
                movementSpeed = normalSpeed;
            }

        }

        else 
        {
            rigidBody.velocity = new Vector3(0f, rigidBody.velocity.y, 0f);
        }
    }

    public void Movement(InputValue value)
    {
        var movementInput = value.Get<Vector2>();
        _currentMovement = new Vector3(movementInput.x, 0, movementInput.y);
    }

    public void JumpLogic()
    {
        if (_jumpCoroutine != null)
            StopCoroutine(_jumpCoroutine);
        _jumpCoroutine = StartCoroutine(JumpCoroutine());
    }

    public void SprintStartLogic(InputValue value)
    {
        var sprintInput = value.Get<float>();
        SprintPressed();
    }

    public void SprintFinishLogic(InputValue value)
    {
        var sprintInput = value.Get<float>();
        SprintReleased();
    }

    private void SprintPressed() 
    {
        _isSprinting = true;
    }

    private void SprintReleased()
    {
        _isSprinting = false;
    }

    private IEnumerator JumpCoroutine()
    {
        if (!feetPivot)
            yield break;

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