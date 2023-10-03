using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementDomino : MonoBehaviour
{
    private static SceneManagementDomino instance;
    private GameObject objectContainer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Find the ObjectContainer only once
        objectContainer = GameObject.Find("ObjectContainer");

        // Check the current active scene when the script starts
        Scene currentScene = SceneManager.GetActiveScene();
        HandleObjectContainer(currentScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HandleObjectContainer(scene);
    }

    private void HandleObjectContainer(Scene scene)
    {
        if (objectContainer != null)
        {
            if (scene.name == "TEST_f")
            {
                objectContainer.SetActive(true);
            }
            else
            {
                objectContainer.SetActive(false);
            }
        }
    }
}