using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    private int saveCoins;

    void Start()
    {
        saveCoins = PlayerPrefs.GetInt("Score", 0);
        coinText.text = saveCoins.ToString();
    }
}