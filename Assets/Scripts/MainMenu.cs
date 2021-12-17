using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // load the game when play button is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // quit if quit is pressed
    public void QuitGame()
    {
        Application.Quit();
    }
}
