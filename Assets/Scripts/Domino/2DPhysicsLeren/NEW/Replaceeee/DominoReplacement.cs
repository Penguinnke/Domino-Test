using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominoReplacement : MonoBehaviour
{
    public GameObject objectToCopy;
    private List<GameObject> replacedObjects = new List<GameObject>();
    private bool canReplace = true;
    public float replacementCooldown = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the collided object
        GameObject collidedObject = collision.gameObject;

        // Check if the collided object has already been replaced and if replacement is allowed
        if (!replacedObjects.Contains(collidedObject) && canReplace)
        {
            // Set replacement cooldown
            canReplace = false;
            StartCoroutine(StartReplacementCooldown());

            // Create a copy of objectToCopy
            GameObject copyObject = Instantiate(objectToCopy, collidedObject.transform.position, collidedObject.transform.rotation);

            // Set the copyObject's position to the exact same position as the collidedObject
            copyObject.transform.position = collidedObject.transform.position;
            copyObject.SetActive(true);

            // Add the collided object to the replacedObjects list
            replacedObjects.Add(collidedObject);

            // Destroy the collided object with a delay
            StartCoroutine(DestroyObjectWithDelay(collidedObject));
        }
    }

    private IEnumerator DestroyObjectWithDelay(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay duration as needed
        Destroy(objectToDestroy);
    }

    private IEnumerator StartReplacementCooldown()
    {
        yield return new WaitForSeconds(replacementCooldown);
        canReplace = true;
    }
}