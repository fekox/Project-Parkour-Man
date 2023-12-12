using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Sets turret movement when aiming, view range and firing.
/// </summary>
public class Turret : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private float range = 15f;

    [SerializeField] private float fireRate = 1f;

    [SerializeField] private float fireCountDown = 0.5f;

    [Header("Setup")]

    [SerializeField] private Transform turret;

    [SerializeField] private Transform firePoint;

    [SerializeField] private string playerTag = "Player";

    [SerializeField] private string functionTime = "UpdateTarget";

    [SerializeField] private float turnSpeed = 10f;

    [SerializeField] private GameObject bulletPrefab;

    private Transform target;

    /// <summary>
    /// Ivokes the Update Target Function
    /// </summary>
    void Start()
    {
        InvokeRepeating(functionTime, 0f, 0.5f);
    }

    /// <summary>
    /// The distance at which the player is from the turret is calculated.To know if the player is in the attack area or not.
    /// </summary>
    void UpdateTarget()
    {
        GameObject[] PlayerTarget = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in PlayerTarget)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }

        else
        {
            target = null;
        }
    }

    /// <summary>
    /// If the player is in the attack area the turret looks at the player constantly.
    /// </summary>
    void Update()
    {
        if (target == null) 
        {
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turret.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown <= 0f)
        {
            shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    /// <summary>
    /// Turret Shot system.
    /// </summary>
    void shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetTarget(target);
        }

    }

    /// <summary>
    /// Draw the gizmos to see the attack area of the turret.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
