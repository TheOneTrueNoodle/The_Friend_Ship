using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public void Transition()
    {
        SceneManager.LoadScene("Declan");
        FindObjectOfType<AudioManager>().Stop("StartMenuTheme");
        FindObjectOfType<AudioManager>().Stop("StartMenuSounds");
        FindObjectOfType<AudioManager>().Play("GamePlayTheme");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
