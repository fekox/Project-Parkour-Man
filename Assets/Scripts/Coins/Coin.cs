using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The coin is destroyed when the player collides 
/// with it and a pick up sound is played.
/// </summary>
public class Coin : MonoBehaviour
{
    [SerializeField] private int value;

    [SerializeField] private string playerTag;

    [SerializeField] private string  coinSFX;

    [SerializeField] private SoundsPlayer soundsPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag)) 
        {
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);

            soundsPlayer.PlaySFX(coinSFX);
        }
    }
}