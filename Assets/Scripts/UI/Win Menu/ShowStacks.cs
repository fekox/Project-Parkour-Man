using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowStacks : MonoBehaviour
{
    [SerializeField] public TMP_Text showTime;

    public float timer;

    private void Star()
    {
        showTime.text = string.Format("{00:00}", timer);
    }
}
