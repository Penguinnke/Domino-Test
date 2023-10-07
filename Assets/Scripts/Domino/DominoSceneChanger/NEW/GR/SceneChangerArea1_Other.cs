using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerArea1_Other : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;

    public Vector3 areaCenter;  // The center of the area
    public Vector3 areaSize;    // The size of the area

    public string[] _dominoTagTRUE;

    public float delayInSeconds = 8f; // Public delay time in seconds

    public string FinishedEra = "FinishedEra"; //You finished that era!! :D

    private void Start()
    {
        //isCollisionDetectedRight = false;
        colliding = false;
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {

        foreach (string tag in _dominoTagTRUE)
        {
            if (_collision.gameObject.tag == tag)
            {
                    if (_collision.gameObject.tag == tag)
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
            }
        }
    }

    private void ChangeSceneAfterDelay()
    {
        // Access the shared list from the SharedSceneList script
        List<string> scenes = SharedSceneList.Instance.Scenes;

        if (scenes.Count > 0)
        {
            int randomIndex = Random.Range(0, scenes.Count);
            string randomSceneName = scenes[randomIndex];
            scenes.RemoveAt(randomIndex);
            SceneManager.LoadScene(randomSceneName);
        }
        else
        {
            Debug.Log("No scenes left in the list.");
            SceneManager.LoadScene(FinishedEra);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        // Draw a wireframe cube to represent the area
        Gizmos.DrawWireCube(areaCenter, areaSize);
    }
}