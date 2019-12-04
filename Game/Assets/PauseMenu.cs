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
        //Attempt player = new Attempt();

        GameObject playercurr = GameObject.Find("Player");



        //SimpleHealthBar healthbar = new SimpleHealthBar();

        //save.health = healthbar.GetCurrentFraction;
        //save.exp = exp;
        save.gamedate = System.DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        save.scene = SceneManager.GetActiveScene().name;
        save.currentX = playercurr.transform.localPosition.x;
        save.currentY = playercurr.transform.localPosition.y;

        return save;
    }

    public void SaveGame()
    {
        // create save object
        Save save = CreateSaveGameObject();

        // save as json
        //Directory.CreateDirectory(Application.dataPath + "/saves/");
        Directory.CreateDirectory("./saves/");
        //string path = (Application.dataPath + "/saves/gamesave.json");
        string path = ("./saves/gamesave.json");
        string json = JsonUtility.ToJson(save);

        StreamWriter sw = File.CreateText(path); // if file doesnt exist, make the file in the specified path

        sw.Close();
        File.WriteAllText(path, json); // fill the file with the data(json)

        Debug.Log("Saving as JSON: " + json);

    }
}
