using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerVersion2 : MonoBehaviour
{
    public List<SceneChangerArea> areas;
    private bool anyAreaHasScenesLeft = false;

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Debug.Log("Collision!");

        foreach (var area in areas)
        {
            if (!area.isActive)
                continue;

            Vector3 objectPosition = transform.position;
            Vector3 areaHalfExtents = area.size * 0.5f;
            Vector3 areaMinBounds = area.center - areaHalfExtents;
            Vector3 areaMaxBounds = area.center + areaHalfExtents;
            bool isInsideArea =
                objectPosition.x >= areaMinBounds.x &&
                objectPosition.x <= areaMaxBounds.x &&
                objectPosition.y >= areaMinBounds.y &&
                objectPosition.y <= areaMaxBounds.y;

            if (Random.value <= 0.05f && isInsideArea)
            {
                Debug.Log("5% chance in Area");

                // Add a delay before changing the scene
                Invoke("ChangeSceneAfterDelay", area.delayInSeconds);
            }
            else
            {
                Debug.Log("95% Scene not changed in Area");
            }

            if (!isInsideArea)
            {
                Debug.Log("Outside Area");
            }
        }
    }

    private void ChangeSceneAfterDelay()
    {
        anyAreaHasScenesLeft = false; // Initialize the variable to false

        foreach (var area in areas)
        {
            if (!area.isActive)
                continue;

            if (area.scenes.Count > 0)
            {
                anyAreaHasScenesLeft = true; // Set to true if any area has scenes left

                int randomIndex = Random.Range(0, area.scenes.Count);
                string randomSceneName = area.scenes[randomIndex];
                area.scenes.RemoveAt(randomIndex);
                SceneManager.LoadScene(randomSceneName);
                return; // Exit the method after changing the scene
            }
        }

        // If no areas have scenes left, change the scene to the ending scene
        if (!anyAreaHasScenesLeft)
        {
            Debug.LogWarning("No scenes left in any area. Changing to EndingScene.");
             SceneManager.LoadScene(areas[0].endingScene);
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var area in areas)
        {
            if (!area.isActive)
                continue;

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(area.center, area.size);
        }
    }
}