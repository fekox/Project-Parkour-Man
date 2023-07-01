using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// When the player collides with a gameObject 
/// the scene is changed.
/// </summary>
public class NextLevel : MonoBehaviour
{
    [SerializeField] private string levelName;

    [SerializeField] private string playerTag;

    private void OnTriggerEnter(Collider next)
    {
        if (next.gameObject.CompareTag(playerTag))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
