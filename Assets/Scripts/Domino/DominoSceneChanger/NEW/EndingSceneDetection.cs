using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneDetection : MonoBehaviour
{
    public int EndingCount = 0;

    public bool era3Finished = false;
    public bool era1Finished = false;
    public bool era2Finished = false;

    private void Update()
    {
        if (SharedSceneList.Instance != null && SharedSceneList.Instance.Scenes.Count == 0)
        {
            EndingCount += 1;
        }

        // Check if the "FinishedEra3" scene is loaded and finished.
        if (SceneManager.GetSceneByName("FinishedEra3").isLoaded && era3Finished == false)
        {
            era3Finished = true;
        }

        // Check if the "FinishedEra1" scene is loaded and finished.
        if (SceneManager.GetSceneByName("FinishedEra1").isLoaded && era1Finished == false)
        {
            era1Finished = true;
        }

        // Check if the "FinishedEra2" scene is loaded and finished.
        if (SceneManager.GetSceneByName("FinishedEra2").isLoaded && era2Finished == false)
        {
            era2Finished = true;
        }

        if (EndingCount == 3 && era1Finished && era2Finished && era3Finished)
        {
            Debug.Log("End game");
        }
    }
}
