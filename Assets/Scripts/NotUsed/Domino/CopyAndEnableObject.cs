using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class CopyAndEnableObject : MonoBehaviour
{
    public GameObject[] objectsToCopy; // Array of objects to choose from

    public float minX = -10f; // Minimum X-axis value
    public float maxX = 10f; // Maximum X-axis value

    private string savePath = "savedPositions.json"; // Path to the saved data file

    private List<Vector3> savedPositions = new List<Vector3>();

    private Transform objectContainer; // Reference to the ObjectContainer

    private static CopyAndEnableObject instance; // Singleton instance

    private bool disableScriptsFor15Seconds = false;
    private float disableTime = 0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameObject persistent
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded; // Register the scene loaded event

        objectContainer = GameObject.Find("ObjectContainer").transform;
        if (objectContainer == null)
        {
            objectContainer = new GameObject("ObjectContainer").transform;
            DontDestroyOnLoad(objectContainer.gameObject);
        }

        LoadSavedPositions();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TEST_f")
        {
            DisableScriptsFor15Seconds();
        }
    }

  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ObjectCopier();
        }

        // Check if we should disable the scripts
        if (disableScriptsFor15Seconds && Time.time >= disableTime)
        {
            EnableScripts();
        }
    }

    public void ObjectCopier()
    {
        int randomIndex = Random.Range(0, objectsToCopy.Length); // Randomly select an index
        GameObject randomObject = objectsToCopy[randomIndex]; // Get the randomly selected object

        GameObject copiedObject = Instantiate(randomObject, objectContainer);

        float randomX = Random.Range(minX, maxX);

        // Get the y-coordinate of the camera's position
        float cameraY = Camera.main.transform.position.y;

        float zPos = randomObject.transform.position.z;
        copiedObject.transform.position = new Vector3(randomX, cameraY, zPos);

        if (SceneManager.GetActiveScene().name == "TEST_f")
        {
            DisableScriptsFor15Seconds();
        }
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

    private void DisableScriptsFor15Seconds()
    {
        disableScriptsFor15Seconds = true;
        disableTime = Time.time + 9f;

        // Find and disable the specified scripts on objects in objectContainer and its children
        RecursiveDisableScripts(objectContainer);
    }

    private void EnableScripts()
    {
        disableScriptsFor15Seconds = false;

        // Find and re-enable the specified scripts on objects in objectContainer and its children
        RecursiveEnableScripts(objectContainer);
    }

    private void RecursiveDisableScripts(Transform parent)
    {
        foreach (Transform child in parent)
        {
            SceneChangerArea1 sceneChanger1 = child.GetComponent<SceneChangerArea1>();
            SceneChangerArea1_Other sceneChanger1Other = child.GetComponent<SceneChangerArea1_Other>();

            if (sceneChanger1 != null)
            {
                sceneChanger1.enabled = false;
            }

            if (sceneChanger1Other != null)
            {
                sceneChanger1Other.enabled = false;
            }

            // Recursively search for child objects
            RecursiveDisableScripts(child);
        }
    }

    private void RecursiveEnableScripts(Transform parent)
    {
        foreach (Transform child in parent)
        {
            SceneChangerArea1 sceneChanger1 = child.GetComponent<SceneChangerArea1>();
            SceneChangerArea1_Other sceneChanger1Other = child.GetComponent<SceneChangerArea1_Other>();

            if (sceneChanger1 != null)
            {
                sceneChanger1.enabled = true;
            }

            if (sceneChanger1Other != null)
            {
                sceneChanger1Other.enabled = true;
            }

            // Recursively search for child objects
            RecursiveEnableScripts(child);
        }
    }

    
}