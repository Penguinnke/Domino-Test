using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerArea1 : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;
    public List<string> Scenes;

    public Vector3 areaCenter;  // The center of the area
    public Vector3 areaSize;    // The size of the area

    public float delayInSeconds = 8f; // Public delay time in seconds

    public string EndingScene = "EndingScene";

    private void Start()
    {
        //isCollisionDetectedRight = false;
        colliding = false;
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Debug.Log("Collision!");
        colliding = true;
        isCollisionDetectedRight = true;

        // Get the position of the object
        Vector3 objectPosition = transform.position;

        // Calculate the half extents of the area (half of its size)
        Vector3 areaHalfExtents = areaSize * 0.5f;

        // Calculate the minimum and maximum bounds of the area
        Vector3 areaMinBounds = areaCenter - areaHalfExtents;
        Vector3 areaMaxBounds = areaCenter + areaHalfExtents;

        // Check if the object is within the area
        bool isInsideArea =
            objectPosition.x >= areaMinBounds.x &&
            objectPosition.x <= areaMaxBounds.x &&
            objectPosition.y >= areaMinBounds.y &&
            objectPosition.y <= areaMaxBounds.y;

        if (Random.value <= 0.05f && isInsideArea && isCollisionDetectedRight)
        {
            Debug.Log("5% chance Area1");

            // Add a delay before changing the scene
            Invoke("ChangeSceneAfterDelay", delayInSeconds);
        }
        else
        {
            Debug.Log("95% Scene not changed Area1");
        }

        if (!isInsideArea)
        {
            Debug.Log("Outside Area Area1");
        }
    }

    // Method to change the scene after the delay
    private void ChangeSceneAfterDelay()
    {
        // Check if there are scenes left in the list
        if (Scenes.Count > 0)
        {
            // Choose a random index from the list
            int randomIndex = Random.Range(0, Scenes.Count);

            // Get the randomly selected scene name
            string randomSceneName = Scenes[randomIndex];

            // Remove the selected scene from the list
            Scenes.RemoveAt(randomIndex);

            // Load the randomly selected scene
            SceneManager.LoadScene(randomSceneName);
        }
        else
        {
            // If the list is empty, you may want to handle this case (e.g., display a message or do something else)
            Debug.LogWarning("No scenes left in the list.");
            SceneManager.LoadScene(EndingScene);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        // Draw a wireframe cube to represent the area
        Gizmos.DrawWireCube(areaCenter, areaSize);
    }
}