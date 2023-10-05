using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerGame1 : MonoBehaviour
{
    public List<Vector3> spawnPoints_Vaas1 = new List<Vector3>();
    public GameObject Vaas1; // Reference to the object you want to move
    private bool hasMoved = false; // Add a flag to track if the object has already moved
    
    public List<Vector3> spawnPoints_Vaas2 = new List<Vector3>();
    public GameObject Vaas2; 
    private bool hasMoved2 = false; 
    
    public List<Vector3> spawnPoints_Vaas3 = new List<Vector3>();
    public GameObject Vaas3; 
    private bool hasMoved3 = false; 

    public List<Vector3> spawnPoints_Vaas4 = new List<Vector3>();
    public GameObject Vaas4; 
    private bool hasMoved4 = false; 

    private void Start()
    {
        if (!hasMoved) // Check if the object has already moved
        {
            MoveVaas1ToRandomPosition();
            hasMoved = true; // Set the flag to true to prevent further moves
        }

        if (!hasMoved2) 
        {
            MoveVaas2ToRandomPosition();
            hasMoved2 = true; 
        }

        if (!hasMoved3) 
        {
            MoveVaas3ToRandomPosition();
            hasMoved3 = true; 
        }

        if (!hasMoved4)
        {
            MoveVaas4ToRandomPosition();
            hasMoved4 = true; 
        }
    }

    private void MoveVaas1ToRandomPosition()
    {
        if (spawnPoints_Vaas1.Count == 0)
        {
            Debug.LogError("No spawn points defined.");
            return;
        }

        if (Vaas1 == null)
        {
            Debug.LogError("No object to move assigned.");
            return;
        }

        // Get a random spawn point from the spawnPoints list
        int randomIndex = Random.Range(0, spawnPoints_Vaas1.Count);
        Vector3 randomSpawnPoint = spawnPoints_Vaas1[randomIndex];

        // Move the object to the random spawn point
        Vaas1.transform.position = randomSpawnPoint;
    }


    private void MoveVaas2ToRandomPosition()
    {
        if (spawnPoints_Vaas2.Count == 0)
        {
            Debug.LogError("No spawn points defined.");
            return;
        }

        if (Vaas2 == null)
        {
            Debug.LogError("No object to move assigned.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints_Vaas2.Count);
        Vector3 randomSpawnPoint2 = spawnPoints_Vaas2[randomIndex];

        Vaas2.transform.position = randomSpawnPoint2;
    }

    private void MoveVaas3ToRandomPosition()
    {
        if (spawnPoints_Vaas3.Count == 0)
        {
            Debug.LogError("No spawn points defined.");
            return;
        }

        if (Vaas3 == null)
        {
            Debug.LogError("No object to move assigned.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints_Vaas3.Count);
        Vector3 randomSpawnPoint3 = spawnPoints_Vaas3[randomIndex];

        Vaas3.transform.position = randomSpawnPoint3;
    }

    private void MoveVaas4ToRandomPosition()
    {
        if (spawnPoints_Vaas4.Count == 0)
        {
            Debug.LogError("No spawn points defined.");
            return;
        }

        if (Vaas4 == null)
        {
            Debug.LogError("No object to move assigned.");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints_Vaas4.Count);
        Vector3 randomSpawnPoint4 = spawnPoints_Vaas4[randomIndex];

        Vaas4.transform.position = randomSpawnPoint4;
    }
}
