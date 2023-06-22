using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    public SFXPlayer sfxPlayer;

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
