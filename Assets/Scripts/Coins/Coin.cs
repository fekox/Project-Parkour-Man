using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Documentation - Add summary
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
        //TODO: Fix - Hardcoded value
        if (other.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);

            //TODO: Fix - Hardcoded value
            sfxPlayer.PlaySFX("Coin");
        }
    }
}