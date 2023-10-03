using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CopyAndEnableObject : MonoBehaviour
{
    public GameObject[] objectsToCopy; // Array of objects to choose from

    public float minX = -10f; // Minimum X-axis value
    public float maxX = 10f; // Maximum X-axis value
    public float minY = -5f; // Minimum Y-axis value
    public float maxY = 5f; // Maximum Y-axis value

    private string savePath = "savedPositions.json"; // Path to the saved data file

    private List<Vector3> savedPositions = new List<Vector3>();

    private Transform objectContainer; // Reference to the ObjectContainer

    void Start()
    {
        objectContainer = GameObject.Find("ObjectContainer").transform;
        //objectContainer = new GameObject("ObjectContainer").transform;
        DontDestroyOnLoad(objectContainer.gameObject); // Make the ObjectContainer persistent

        LoadSavedPositions();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ObjectCopier();
        }
    }

    public void ObjectCopier()
    {
        int randomIndex = Random.Range(0, objectsToCopy.Length); // Randomly select an index
        GameObject randomObject = objectsToCopy[randomIndex]; // Get the randomly selected object

        GameObject copiedObject = Instantiate(randomObject, objectContainer);
        copiedObject.SetActive(true);

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        float zPos = randomObject.transform.position.z;
        copiedObject.transform.position = new Vector3(randomX, randomY, zPos);

        // Save the position of the copied object
        SaveObjectPosition(copiedObject.transform.position);
    }

    private void SaveObjectPosition(Vector3 position)
    {
        savedPositions.Add(position);

        // Serialize and save to disk
        string json = JsonUtility.ToJson(savedPositions);
        File.WriteAllText(savePath, json);

        Debug.Log("Position saved: " + position);
    }

    private void LoadSavedPositions()
    {
        Debug.Log("LoadSavedPositions method called."); // Add this line for debugging

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            savedPositions = JsonUtility.FromJson<List<Vector3>>(json);

            // Loop through saved positions and instantiate objects
            foreach (var position in savedPositions)
            {
                int randomIndex = Random.Range(0, objectsToCopy.Length); // Randomly select an index
                GameObject randomObject = objectsToCopy[randomIndex]; // Get the randomly selected object

                GameObject copiedObject = Instantiate(randomObject, objectContainer);
                copiedObject.SetActive(true);

                float zPos = randomObject.transform.position.z;
                copiedObject.transform.position = new Vector3(position.x, position.y, zPos);

                Debug.Log("Position loaded: " + position);
            }
        }
        else
        {
            Debug.Log("No saved positions found.");
        }
    }
}