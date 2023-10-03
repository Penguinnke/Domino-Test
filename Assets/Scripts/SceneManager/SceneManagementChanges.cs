using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class SceneState
{
    // Define the data you want to save
    public Vector3 playerPosition;
    // Add other variables as needed
    
    // Constructor
    public SceneState(Vector3 playerPos)
    {
        playerPosition = playerPos;
    }
}

public class SceneStateManager : MonoBehaviour
{
    private string saveFilePath = "scene1state.dat";
    private SceneState currentSceneState;

    void Start()
    {
        LoadState();
    }

    public void SaveState()
    {
        // Gather the state information you want to save
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        currentSceneState = new SceneState(playerPos);

        // Serialize and save the state to a file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveFilePath);
        bf.Serialize(file, currentSceneState);
        file.Close();

        Debug.Log("Scene 1 state saved.");
    }

    public void LoadState()
    {
        if (File.Exists(Application.persistentDataPath + "/" + saveFilePath))
        {
            // Deserialize and load the saved state from the file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFilePath, FileMode.Open);
            currentSceneState = (SceneState)bf.Deserialize(file);
            file.Close();

            // Apply the loaded state to your scene (e.g., move the player to the saved position)
            GameObject.FindGameObjectWithTag("Player").transform.position = currentSceneState.playerPosition;

            Debug.Log("Scene 1 state loaded.");
        }
        else
        {
            Debug.Log("No saved state found.");
        }
    }

    public void TransitionToScene2()
    {
        SaveState();
        SceneManager.LoadScene("Scene2");
    }
}