using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private int currentCoins = 0;

    public static CoinCounter instance;

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