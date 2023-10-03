using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerArea1 : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;
    public string[] Scenes;

    public Vector3 areaCenter;  // The center of the area
    public Vector3 areaSize;    // The size of the area
    
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

                if (Random.value <= 0.25f && isInsideArea && isCollisionDetectedRight)
                {
                    Debug.Log("25% chance Area1");
                    string randomSceneName = Scenes[Random.Range(0, Scenes.Length)];
                    // Load the randomly selected scene
                    SceneManager.LoadScene(randomSceneName);
                } else 
                {
                    Debug.Log("Scene not changed Area1");
                }

                if (!isInsideArea)
                {
                    Debug.Log("Outside Area Area1");
                }
        
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        // Draw a wireframe cube to represent the area
        Gizmos.DrawWireCube(areaCenter, areaSize);
    }
}