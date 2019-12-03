using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Game : MonoBehaviour
{
    public string gamedate;
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
        Debug.Log("Game Saved");
    }
}
