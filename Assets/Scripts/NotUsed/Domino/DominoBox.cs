using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoBox : MonoBehaviour
{
    public int maxObjects = 10; // Maximum number of objects allowed on the platform
    private int currentObjects = 0; // Current number of objects on the platform

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentObjects++;

        if (currentObjects >= maxObjects)
        {
            // Box is full
            Debug.Log("Box is full!");
            // Additional actions when the box is full
        }

        // Disable the object when it enters the box
        collision.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentObjects--;

        if (currentObjects < maxObjects)
        {
            // Box is no longer full
            Debug.Log("Box is no longer full!");
            // Additional actions when the box is no longer full
        }
    }
}