using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool pauseEnabled = false;

    private void Start()
    {
        pauseEnabled = false;
        Time.timeScale = 1;
        AudioListener.volume = 1;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //check if game is already paused        
            if (pauseEnabled == true)
            {
                //unpause the game
                pauseEnabled = false;
                Time.timeScale = 1;
                AudioListener.volume = 1;
                SceneManager.UnloadScene("Pause Menu");
            }

            //else if game isn't paused, then pause it
            else if (pauseEnabled == false)
            {
                pauseEnabled = true;
                AudioListener.volume = 0;
                Time.timeScale = 0;
                SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);
            }
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

