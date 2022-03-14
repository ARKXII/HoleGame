using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
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
        GameManager.IsInputEnabled = false;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.07f;
        IsPaused = true;
    }

    public void Resume()
    {
        GameManager.IsInputEnabled = true;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }
}
