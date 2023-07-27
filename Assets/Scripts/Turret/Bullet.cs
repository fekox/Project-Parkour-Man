using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the bullet move and destroy itself when colliding with objects of specific tags.
/// </summary>
public class Bullet : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private string playerTag = "Player";

    [Header("Setup")]
    
    [SerializeField] private float speed = 70f;

    private Transform target;

    /// <summary>
    /// Sets the target.
    /// </summary>
    /// <param name="_target"></param>
    public void Seek(Transform _target)
    {
        target = _target;
    }

    /// <summary>
    /// Moves the bullet and destroys it if the target is null.
    /// </summary>
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(new Vector3(0f, 0f, distanceThisFrame));
    }

    /// <summary>
    /// Destroy de bullet.
    /// </summary>
    void HitTarget()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// When the bullet collides with the plumber with the bullet collision it is destroyed.
    /// </summary>
    /// <param name="bullet"></param>
    void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.CompareTag(playerTag)) 
        {
            HitTarget();
        }
    }
}