using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    //TODO: TP2 - Syntax - Fix declaration order
    [SerializeField] private TMP_Text coinText;

    [SerializeField] private int currentCoins = 0;

    public static CoinCounter instance;

    private int saveCoins = 0;

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    void Awake()
    {
        //BUG: Could have multiple instances in a scene
        instance = this;
    }

    void Start()
    {
        //TODO: Fix - Shouldn't this value be loaded from playerPrefs?
        coinText.text = currentCoins.ToString();
    }

    public void IncreaseCoins(int value) 
    {
        currentCoins += value;
        saveCoins = currentCoins;
        //TODO: TP2 - SOLID - Not sure if this will be replaced by ShowCoins
        coinText.text = currentCoins.ToString();

        PlayerPrefs.SetInt("Score", saveCoins);
    }
}