using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// The player's current lives are displayed and a lives value is subtracted.
/// </summary>
public class LifesCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text lifesText;

    [SerializeField] private PlayerLose playerLose;

    [SerializeField] private int playerMaxLifes;

    public int playerCurrentLifes = 0;

    /// <summary>
    /// The maximum number of lives is equal to the current lives of the player. 
    /// </summary>
    public void Start()
    {
        playerCurrentLifes = playerMaxLifes;
        lifesText.text = playerCurrentLifes.ToString();
    }

    /// <summary>
    /// A lives value is subtracted.
    /// </summary>
    /// <param name="value"></param>        
    public void SubtractLife(int value)
    {
        playerCurrentLifes -= value;
        lifesText.text = playerCurrentLifes.ToString();
    }
}
