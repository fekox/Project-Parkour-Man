using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;

    private SFXPlayer sfxPlayer;

    private void Start()
    {
        sfxPlayer = GetComponentInParent<SFXPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);

            sfxPlayer.PlaySFX("Coin");
        }
    }
}