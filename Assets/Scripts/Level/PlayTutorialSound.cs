using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTutorialSound : MonoBehaviour
{
    void Start()
    {
        FindAnyObjectByType<AudioManager>().Play("Tutorial Music");
        FindAnyObjectByType<AudioManager>().Play("Tutorial Narrator");
    }
}
