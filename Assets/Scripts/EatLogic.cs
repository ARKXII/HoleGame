using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Eat and Point System
/// </summary>

public class EatLogic : MonoBehaviour
{
    public float Points = 0;
    public HoleScript HoleScript;
    public Text CurrentScoreTxt;
    public Text GameOverScoreTxt;

    private int localInt = 0;

    public GameObject GameOverScreen;
    public GameObject Timer;

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
        } else if (other.gameObject.tag == "Green")                // Only get points for green every two objects
        {
            
            localInt++;
            if (localInt % 2 == 0)
            {
                Progress();
                localInt = 0;
            }
        } else
        {
            Progress();
        }
        Destroy(other.gameObject);
        UpdateScore();
        winCondition();
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
        CurrentScoreTxt.text = Points.ToString();               // Push points to canvas txt
        GameOverScoreTxt.text = Points.ToString();               // Push points to canvas txt
    }

    private void winCondition()
    {
        if (Points == GameManager.WinCondition)
        {
            GameManager.IsInputEnabled = false;
            GameOverScreen.SetActive(true);
            Timer.SetActive(false);
        }
    }
}
