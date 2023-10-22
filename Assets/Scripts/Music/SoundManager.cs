using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public string EndScene;

    private AudioSource audioSource; // Store a reference to the AudioSource component.

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // Get the AudioSource component and store it.
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the current scene is the end scene and destroy the SoundManager.
        if (SceneManager.GetActiveScene().name == EndScene && audioSource != null)
        {
            audioSource.Pause();
            Destroy(gameObject); // Destroy the SoundManager in the EndScene.
        }
    }
}