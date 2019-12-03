using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        //SimpleHealthBar healthbar = new SimpleHealthBar();

        //save.health = healthbar.GetCurrentFraction;
        //save.exp = exp;
        save.gamedate = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        save.scene = SceneManager.GetActiveScene().name;
        return save;
    }

    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        // 3
        Debug.Log("Saved game at: " + save.gamedate);

        Debug.Log("Game Saved");
    }
}

