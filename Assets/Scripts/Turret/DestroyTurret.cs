using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyTurret : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    [SerializeField] private string coinSFX;

    public SoundsPlayer soundsPlayer;

    public UnityEvent<GameObject> onDeath;

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
}
