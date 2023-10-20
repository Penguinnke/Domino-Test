using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneDominoDeleter : MonoBehaviour
{
    public string targetSceneName;
    public List<GameObject> objectsToDestroy;

    private bool sceneLoaded = false;

    private void Start()
    {
        // Mark this GameObject as "Don't Destroy On Load"
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == targetSceneName)
        {
            sceneLoaded = true;
            DestroyObjectsInList();
        }
        else
        {
            sceneLoaded = false;
        }
    }

    private void Update()
    {
        if (sceneLoaded)
        {
            // Check if the objects in the list still exist in the scene
            DestroyObjectsInList();
        }
    }

    private void DestroyObjectsInList()
    {
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }
}
