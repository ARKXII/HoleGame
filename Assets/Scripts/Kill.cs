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
        if (other.gameObject.tag == "Red")                         // Find red tag
        {
            for (int x = 0; x < GameManager.redValue; x++)         // Get 5 points for reds
                Progress();                                        // O_o
            
        } else if (other.gameObject.tag == "Yellow")               // Find yellow tag
        {
            for (int x = 0; x < GameManager.yellowValue; x++)      // Get 3 points for yellow 
                Progress();
        } else
        {
            Progress();
        }
        Destroy(other.gameObject);
        UpdateScore();
    }

    private void Progress()
    {
        Points++;
        if (Points % 20 == 0)                       // Grow hole every 20 points
        {
            StartCoroutine(HoleScript.BigHole());   // Call BigHole() for hole bigger
        }
    }

    private void UpdateScore()
    {
        txt.text = Points.ToString();               // Push points to canvas txt
    }
}
