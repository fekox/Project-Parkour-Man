using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuSound : MonoBehaviour
{
    void Start()
    {
        FindAnyObjectByType<AudioManager>().Play("Menu Music");
    }
}
