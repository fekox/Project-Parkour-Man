using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using System.Runtime.CompilerServices;

/// <summary>
/// Manages the player's camera.
/// </summary>
public class PlayerLook : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private Transform playerBody;

    [SerializeField] private Transform camHolder;

    [Header("Movement")]

    [SerializeField] private float cameraSensitivity = 0f;

    private float mouseSensitivity = 30f;

    private float joystickSensitivity = 130f;

    private Vector2 mouseRot;

    private string[] joystickNames;

    private float xRotation;

    /// <summary>
    /// Checks if a controller is conected. 
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckController()
    {
        while (true) 
        {
            string[] currentJoystickNames = Input.GetJoystickNames();

            if (!JoystickNamesAreEqual(joystickNames, currentJoystickNames))
            {
                if (currentJoystickNames.Length > 0 && !IsDefaultJoystickName(currentJoystickNames[0]))
                {
                    SetCameraSensitivity(joystickSensitivity);
                }

                else
                {
                    SetCameraSensitivity(mouseSensitivity);
                }

                joystickNames = currentJoystickNames;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    /// <summary>
    /// Calls the coroutine and the cursor is set to locked.
    /// </summary>
    void Start()
    {
        StartCoroutine(CheckController());
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Do the camera movement logic.
    /// </summary>
    void Update()
    {
        CameraMovement();
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
        float duration = 0.35f;

        transform.DOLocalRotate(new Vector3(0, 0, zTilt), duration);
    }

    /// <summary>
    /// The camera follows the cursor.
    /// </summary>
    private void CameraMovement() 
    {
        float maxClamp = 70f;
        float minClamp = -70f;

        var mouseX = mouseRot.x * cameraSensitivity * Time.deltaTime;
        var mouseY = mouseRot.y * cameraSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minClamp, maxClamp);

        camHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// Detects whether the name of the connected joysticks is the same as the default one or not.
    /// </summary>
    private bool JoystickNamesAreEqual(string[] arr1, string[] arr2)
    {
        if (arr1 == null || arr2 == null || arr1.Length != arr2.Length) 
        {
            return false;
        }

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i]) 
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Detects if there is a default or null joystic connected.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private bool IsDefaultJoystickName(string name)
    {
        string unknown = "Unknown";

        return string.IsNullOrEmpty(name) || name.Equals(unknown);
    }

    /// <summary>
    /// Set the camera sensitivity.
    /// </summary>
    /// <param name="newSensitivity"></param>
    private void SetCameraSensitivity(float newSensitivity) 
    {
        cameraSensitivity = newSensitivity;
    }
}