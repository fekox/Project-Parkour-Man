using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player fly movement logic.
/// </summary>
public class FlyMovement : MonoBehaviour
{
    [SerializeField] private float flyMovementSpeed;

    public bool GoUp = false;

    public bool GoDown = false;

    /// <summary>
    /// IF the boolean is true execute the logic of fly up or fly down.
    /// </summary>
    private void Update()
    {
        if (GoUp == true) 
        {
            FlyUpLogic();
        }

        if (GoDown == true) 
        {
            FlyDownLogic();
        }
    }

    /// <summary>
    /// Move the player Up.
    /// </summary>
    public void FlyUpLogic() 
    {
        transform.Translate(Vector3.up * flyMovementSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Move the player down.
    /// </summary>
    public void FlyDownLogic() 
    {
        transform.Translate(Vector3.down * flyMovementSpeed * Time.deltaTime);
    }
}