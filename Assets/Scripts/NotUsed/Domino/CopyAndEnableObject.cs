using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAndEnableObject : MonoBehaviour
{
    public GameObject[] objectsToCopy; // Array of objects to choose from

    public float minX = -10f; // Minimum X-axis value
    public float maxX = 10f; // Maximum X-axis value
    public float minY = -5f; // Minimum Y-axis value
    public float maxY = 5f; // Maximum Y-axis value

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

        GameObject copiedObject = Instantiate(randomObject);
        copiedObject.SetActive(true);

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        float zPos = randomObject.transform.position.z;
        copiedObject.transform.position = new Vector3(randomX, randomY, zPos);
    }
}