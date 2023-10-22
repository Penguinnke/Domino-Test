using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string targetSceneName; 
    public AudioClip buttonsound; 

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SceneChanger()
    {
        // Play the sound effect before changing the scene
        if (audioSource != null && buttonsound != null)
        {
            audioSource.PlayOneShot(buttonsound);
        }

        // Delay the scene change if you want the sound to finish playing
        StartCoroutine(ChangeSceneAfterSound());
    }

    private IEnumerator ChangeSceneAfterSound()
    {
        // Wait for the duration of the sound effect
        yield return new WaitForSeconds(buttonsound.length);

        // Load the target scene
        SceneManager.LoadScene(targetSceneName);
    }
}