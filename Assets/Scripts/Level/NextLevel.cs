using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string LevelName;

    private void OnTriggerEnter(Collider next)
    {
        if (next.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(LevelName);
        }
    }

}
