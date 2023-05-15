using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinText;

    public int currentCoins = 0;

    private int saveCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = currentCoins.ToString();
    }

    public void IncreaseCoins(int value) 
    {
        currentCoins += value;
        saveCoins = currentCoins;
        coinText.text = currentCoins.ToString();

        PlayerPrefs.SetInt("Score", saveCoins);
    }
}
