using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

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
}
