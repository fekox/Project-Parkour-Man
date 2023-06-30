using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Show the coins on screen and save the
/// current coins in PlayerPrefs.
/// </summary>
public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private int currentCoins = 0;

    [SerializeField] private string scorePlayerPref;

    private int saveCoins = 0;

    public static CoinCounter instance;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }

        else if (instance != null) 
        {
            Destroy(this);
        }
    }

    public void IncreaseCoins(int value) 
    {
        currentCoins += value;
        saveCoins = currentCoins;
        //TODO: TP2 - SOLID - Not sure if this will be replaced by ShowCoins
        coinText.text = currentCoins.ToString();

        PlayerPrefs.SetInt(scorePlayerPref, saveCoins);
    }
}