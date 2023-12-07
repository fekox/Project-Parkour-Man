using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;

/// <summary>
/// If the player collides with the ground and their lives are less than or equal to 0, the lose menu scene is loaded.
/// </summary>
public class PlayerLose : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private LoseMenu loseMenu;

    [SerializeField] private LifesCounter lifeCounter;

    [SerializeField] private string playerLoseTag;

    [SerializeField] private string bulletTag;

    [SerializeField] private int removeLife;

    [SerializeField] private CheatsManager cheatManager;

    /// <summary>
    /// If the player collides with the ground and their lives are less than or equal to 0, the lose menu scene is loaded.
    /// </summary>
    /// <param name="ground"></param>
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag(playerLoseTag) && cheatManager.godMode == false) 
        {
            lifeCounter.SubtractLife(removeLife);

            if (lifeCounter.playerCurrentLifes <= 0)
            {
                loseMenu.LoadLoseMenu();
            }
        }

        if (player.gameObject.CompareTag(bulletTag) && cheatManager.godMode == false)
        {
            lifeCounter.SubtractLife(removeLife);

            if (lifeCounter.playerCurrentLifes <= 0)
            {
                loseMenu.LoadLoseMenu();
            }
        }
    }
}
