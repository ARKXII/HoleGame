using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic Pause Menu logic
/// </summary>

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject PauseButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        GameManager.IsInputEnabled = false;         // Disable input when paused
        PauseMenuUI.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0.07f;                     // Slowmotion gaming
        IsPaused = true;
    }

    public void Resume()
    {
        GameManager.IsInputEnabled = true;          // re enable input
        PauseMenuUI.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
