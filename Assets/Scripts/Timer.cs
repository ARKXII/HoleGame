using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject Self;
    public Text timerText;
    public float timeValueInSeconds = 90;

     // Update is called once per frame
    void Update()
    {
        if (timeValueInSeconds > 0)
        {
            timeValueInSeconds -= Time.deltaTime;
        } else
        {
            timeValueInSeconds = 0;
            GameManager.IsInputEnabled = false;
            GameOverScreen.SetActive(true);
            Self.SetActive(false);
        }
        DisplayTime(timeValueInSeconds);
    }

    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
