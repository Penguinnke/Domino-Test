using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominoReplacement : MonoBehaviour
{
    public GameObject objectToCopy;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("what");
        // // Get the collided object
        // GameObject collidedObject = collision.gameObject;

        // // Create a copy of objectToCopy
        // GameObject copyObject = Instantiate(objectToCopy, collidedObject.transform.position, collidedObject.transform.rotation);

        // // Set the copyObject's position to the exact same position as the collidedObject
        // copyObject.transform.position = collidedObject.transform.position;
        // copyObject.SetActive(true);


        // // Delete the collided object
        // Destroy(collidedObject);
    }
}