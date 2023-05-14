using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject playerSpawn;

    private void OnTriggerEnter(Collider p)
    {
        if (p.gameObject.CompareTag("PlayerDie"))
        {
            player.transform.position = playerSpawn.transform.position;
        }
    }
}   
