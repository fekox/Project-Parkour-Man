using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Show the amount of coins that the player 
/// had collected.
/// </summary>
public class ShowCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private string scorePlayerPref;

    private int saveCoins;

    private int defaultValue = 0;


    /// <summary>
    /// The coins that the player collected are saved in the playerpref.
    /// </summary>
    void Start()
    {
        saveCoins = PlayerPrefs.GetInt(scorePlayerPref, defaultValue);
        coinText.text = saveCoins.ToString();
    }
}