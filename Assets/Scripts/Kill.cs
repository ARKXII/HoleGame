using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Kill : MonoBehaviour
{
    public float Points = 0;
    public HoleScript HoleScript;
    public Text txt;


    // Clear Eaten Objects
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Progress();
        UpdateScore();
    }

    private void Progress()
    {
        Points++;

        if (Points % 20 == 0)   // Grow hole every 20 objects
        {
            StartCoroutine(HoleScript.BigHole());   // Call BigHole() for hole bigger
        }
    }

    private void UpdateScore()
    {
        txt.text = Points.ToString();   // Push points to canvas txt
    }
}
