using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

/// <summary>
/// Manages the player's camera.
/// </summary>
public class PlayerLook : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private Transform playerBody;

    [SerializeField] private Transform camHolder;

    [Header("Movement")]

    [SerializeField] private float mouseSensitivity = 100f;

    private Vector2 mouseRot;

    private float xRotation;

    /// <summary>
    /// The cursor is set to locked.
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// The camera follows the cursor.
    /// </summary>
    void Update()
    {
       var mouseX = mouseRot.x * mouseSensitivity * Time.deltaTime;
       var mouseY = mouseRot.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
     
        camHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// LookLogic receives an input so that it 
    /// can execute the camera movement logic.
    /// </summary>
    /// <param name="inputValue"></param>
    public void LookLogic(InputValue inputValue)
    {
        mouseRot = inputValue.Get<Vector2>();
    }

    /// <summary>
    /// The camera tilts.
    /// </summary>
    /// <param name="zTilt"></param>
    public void DoTilt(float zTilt) 
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.35f);
    }
}