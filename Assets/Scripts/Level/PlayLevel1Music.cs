using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel1Music : MonoBehaviour
{
    void Start()
    {
        FindAnyObjectByType<AudioManager>().Play("Narrator Level 1");
        FindAnyObjectByType<AudioManager>().Play("Music Level 1");
    }
}
