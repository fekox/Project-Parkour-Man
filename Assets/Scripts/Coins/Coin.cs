using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The coin is destroyed when the player collides 
/// with it and a pick up sound is played.
/// </summary>
public class Coin : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private string playerTag;

    [SerializeField] private int value;

    [SerializeField] private string coinSFX;

    [SerializeField] private GameObject pickUpPrefab;

    [Header("References")]
    private CoinsFactory coinsFactory;

    private PickUp coin;

    public SoundsPlayer soundsPlayer;

    public UnityEvent<GameObject> onDeath;

    /// <summary>
    /// Create the coins factory an sets the coins.
    /// </summary>
    private void Start()
    {
        coinsFactory = new CoinsFactory();

        coin = coinsFactory.CreateCoin(value, soundsPlayer, coinSFX);
    }

    /// <summary>
    /// When the player collides with the coin it is destroyed 
    /// and a pick up sound is played.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag)) 
        {
            CoinCounter.instance.IncreaseCoins(value);

            soundsPlayer.PlaySFX(coinSFX);

            onDeath.Invoke(gameObject);
        }
    }
}