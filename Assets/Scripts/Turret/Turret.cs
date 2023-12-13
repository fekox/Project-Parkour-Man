using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Sets turret movement when aiming, view range and firing.
/// </summary>
public class Turret : MonoBehaviour
{
    [Header("Setup")]
   
    [SerializeField] private float range = 15f;

    [SerializeField] private float fireRate = 1f;

    [SerializeField] private float fireCountDown = 0.5f;

    [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private string playerTag = "Player";

    [SerializeField] private string functionName = "UpdateTarget";

    [SerializeField] private string coinSFX;

    [Header("References")]

    [SerializeField] private Transform turret;

    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject bulletPrefab;

    private TurretsFactory turretFactory;

    private Enemy enemyTurret;

    private Transform target;

    public SoundsPlayer soundsPlayer;

    public UnityEvent<GameObject> onDeath;

    /// <summary>
    /// Ivokes the Update Target Function
    /// </summary>
    void Start()
    {
        float repeatRate = 0.5f;

        InvokeRepeating(functionName, 0f, repeatRate);

        turretFactory = new TurretsFactory();

        enemyTurret = turretFactory.CreateTurret(target, turret, range, soundsPlayer, playerTag, coinSFX);
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
            float distanceToPlayer = Vector3.Distance(turret.transform.position, player.transform.position);
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

        Vector3 direction = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(turret.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        turret.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    /// <summary>
    /// Turret Shot system.
    /// </summary>
    void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetTarget(target);
        }

    }

    /// <summary>
    /// When the player collides with the turret, the turret is destroyed.
    /// </summary>
    /// <param name="bullet"></param>
    private void OnTriggerEnter(Collider turret)
    {
        if (turret.gameObject.CompareTag(playerTag))
        {
            soundsPlayer.PlaySFX(coinSFX);

            onDeath.Invoke(gameObject);
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