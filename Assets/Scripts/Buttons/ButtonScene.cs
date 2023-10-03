using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    public AudioSource buttonSound; // Reference to the AudioSource component with the sound
    public AudioClip clickSound;    // The sound to play when the button is clicked

    public void ChangeToScene(string sceneName)
    {
        if (buttonSound != null && clickSound != null)
        {
            buttonSound.PlayOneShot(clickSound); // Play the click sound
        }

        // Delay scene loading slightly (optional)
        StartCoroutine(LoadSceneAfterSound(sceneName));
    }

    private IEnumerator LoadSceneAfterSound(string sceneName)
    {
        // Wait for a short delay before loading the scene (adjust as needed)
        yield return new WaitForSeconds(0.5f);

        // Load the scene
        SceneManager.LoadScene(sceneName);
    }
}