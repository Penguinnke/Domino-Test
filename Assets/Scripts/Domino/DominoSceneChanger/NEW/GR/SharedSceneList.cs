using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedSceneList : MonoBehaviour
{
    public static SharedSceneList Instance { get; private set; }

    public List<string> Scenes = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    //     // Method to change the scene after the delay
    // private void ChangeSceneAfterDelay()
    // {
    //     // Check if there are scenes left in the list
    //     if (Scenes.Count > 0)
    //     {
    //         // Choose a random index from the list
    //         int randomIndex = Random.Range(0, Scenes.Count);

    //         // Get the randomly selected scene name
    //         string randomSceneName = Scenes[randomIndex];

    //         // Remove the selected scene from the list
    //         Scenes.RemoveAt(randomIndex);

    //         // Load the randomly selected scene
    //         SceneManager.LoadScene(randomSceneName);
    //     }
    //     else
    //     {
    //         // If the list is empty, you may want to handle this case (e.g., display a message or do something else)
    //         Debug.Log("No scenes left in the list.");
    //         SceneManager.LoadScene(EndingScene);
    //     }
    // }
}