using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void NewGame()
    {
        PlayerPrefs.SetString("loading", "false");

        SceneManager.LoadScene("LVL1");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void LoadGame()
    {
        // 1

        //if (File.Exists(Application.persistentDataPath + "/saves/gamesave.json"))
        if (File.Exists("./saves/gamesave.json"))
        {
            Attempt player = new Attempt();

            //string json = File.ReadAllText(Application.persistentDataPath + "/saves/gamesave.json");
            string json = File.ReadAllText("./saves/gamesave.json");

            Save save = JsonUtility.FromJson<Save>(json);

            //player.updateHealth(save.health);
            //player.updateExp(save.exp);
            player.play_date = save.gamedate;
            player.current_level = save.scene;

            PlayerPrefs.SetString("loading", "true");

            PlayerPrefs.Save();

            SceneManager.LoadScene(player.current_level);

        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}