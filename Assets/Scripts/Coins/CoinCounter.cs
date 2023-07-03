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

    /// <summary>
    /// If the instance is null instantiate the object, otherwise the object is destroy.
    /// </summary>
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

    /// <summary>
    /// Added a coin to the player's current coins and is displayed on the hud.
    /// </summary>
    /// <param name="value"></param>
    public void IncreaseCoins(int value) 
    {
        currentCoins += value;
        saveCoins = currentCoins;
        coinText.text = currentCoins.ToString();

        PlayerPrefs.SetInt(scorePlayerPref, saveCoins);
    }
}