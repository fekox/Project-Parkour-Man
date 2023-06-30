using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerLook : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private Transform playerBody;

    [SerializeField] private Transform camHolder;

    [Header("Movement")]

    [SerializeField] private float mouseSensitivity = 100f;

    private Vector2 mouseRot;

    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //TODO: Fix - Should be event based
        //TODO: TP2 - Syntax - Fix formatting
       var mouseX = mouseRot.x * mouseSensitivity * Time.deltaTime;
       var mouseY = mouseRot.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
     
        camHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    //TODO: Fix - Using Input related logic outside of an input responsible class
    public void LookLogic(InputValue inputValue)
    {
        mouseRot = inputValue.Get<Vector2>();
    }

    public void DoTilt(float zTilt) 
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.35f);
    }
}