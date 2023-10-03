using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStateManager : MonoBehaviour
{
    // Create a dictionary to store the state of each object
    private Dictionary<GameObject, Vector3> objectStates = new Dictionary<GameObject, Vector3>();

    // Function to save the state of an object
    public void SaveObjectState(GameObject obj)
    {
        if (obj != null)
        {
            objectStates[obj] = obj.transform.position;
        }
    }

    // Function to restore the state of all objects
    public void RestoreObjectStates()
    {
        foreach (var kvp in objectStates)
        {
            GameObject obj = kvp.Key;
            Vector3 position = kvp.Value;
            if (obj != null)
            {
                obj.transform.position = position;
            }
        }
    }
}