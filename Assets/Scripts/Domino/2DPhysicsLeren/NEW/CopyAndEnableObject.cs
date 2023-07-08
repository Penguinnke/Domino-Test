using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAndEnableObject : MonoBehaviour
{
    public GameObject[] objectsToCopy; // Array of objects to choose from

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
        // Additional customization or modifications to the copied object
    }
}
