using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Generic scene switch
/// </summary>

public class LoadScene : MonoBehaviour
{
    public void LoadNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // next scene
    }

    public void LoadPrev()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // previous scene
        Time.timeScale = 1f; // normalize time
        GameManager.IsInputEnabled = true; // enable input

    }

    public void DoExit()
    {
        Application.Quit();
    }
}
