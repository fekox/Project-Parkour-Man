using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTurret : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    /// <summary>
    /// When the player collides with the turret, the turret is destroyed.
    /// </summary>
    /// <param name="bullet"></param>
    private void OnTriggerEnter(Collider turret)
    {
        if (turret.gameObject.CompareTag(playerTag))
        {
            Destroy(gameObject);
        }
    }
}
