using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;

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

    void Pause()
    {
        GameManager.IsInputEnabled = false;         // Disable input when paused
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.07f;                     // Slowmotion gaming
        IsPaused = true;
    }

    public void Resume()
    {
        GameManager.IsInputEnabled = true;          // re enable input
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
