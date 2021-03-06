using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    public GameObject PauseButton;
    public GameObject CreatureMenu;
    
    public void Transition()
    {
        SceneManager.LoadScene("FriendShip");
        FindObjectOfType<AudioManager>().Stop("StartMenuTheme");
        FindObjectOfType<AudioManager>().Play("GamePlayTheme");
        GameIsPaused = false;
        gameObject.SetActive(PauseButton);
        gameObject.SetActive(CreatureMenu);
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

    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
        FindObjectOfType<AudioManager>().Stop("GamePlayTheme");
        FindObjectOfType<AudioManager>().Play("StartMenuTheme");
    }
}
