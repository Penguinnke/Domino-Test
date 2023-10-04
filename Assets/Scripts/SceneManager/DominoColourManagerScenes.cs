using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class DominoColourManagerScenes : MonoBehaviour
{
    private Coroutine enableScriptsCoroutine;

    void Start()
    {
        // Subscribe to the scene reloading event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Disable the scripts when the scene starts
        DisableScripts();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the scene is the "TEST_f" scene
        if (scene.name == "TEST_f")
        {
            // Enable the scripts after a delay
            if (enableScriptsCoroutine != null)
            {
                StopCoroutine(enableScriptsCoroutine);
            }

            enableScriptsCoroutine = StartCoroutine(EnableScriptsAfterDelay());
        }
        else
        {
            // Disable the scripts if the scene is not "TEST_f"
            DisableScripts();
        }
    }

    private void DisableScripts()
    {
        // Find all child objects of the main parent
        Transform[] childTransforms = GetComponentsInChildren<Transform>();

        foreach (Transform child in childTransforms)
        {
            // Check if the child has the scripts you want to disable
            DominoColourZero scriptZero = child.GetComponent<DominoColourZero>();
            DominoColour scriptColour = child.GetComponent<DominoColour>();

            if (scriptZero != null)
                scriptZero.enabled = false;

            if (scriptColour != null)
                scriptColour.enabled = false;
        }
    }

    private IEnumerator EnableScriptsAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);

        // Find all child objects of the main parent again
        Transform[] childTransforms = GetComponentsInChildren<Transform>();

        foreach (Transform child in childTransforms)
        {
            // Check if the child has the scripts you want to enable
            DominoColourZero scriptZero = child.GetComponent<DominoColourZero>();
            DominoColour scriptColour = child.GetComponent<DominoColour>();

            if (scriptZero != null)
                scriptZero.enabled = true;

            if (scriptColour != null)
                scriptColour.enabled = true;
        }
    }

    // Make sure to unsubscribe from the sceneLoaded event when the script is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}