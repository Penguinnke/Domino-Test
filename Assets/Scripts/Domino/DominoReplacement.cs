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

        if (!replacedObjects.Contains(collidedObject) && canReplace)
        {
            canReplace = false;
            StartCoroutine(StartReplacementCooldown());

            GameObject copyObject = Instantiate(objectToCopy, collidedObject.transform.position, collidedObject.transform.rotation);
            copyObject.transform.position = collidedObject.transform.position;
            copyObject.SetActive(true);

            GameObject objectContainer = GameObject.Find("ObjectContainer");

            if (objectContainer != null)
            {
                copyObject.transform.parent = objectContainer.transform;
            }
            else
            {
                Debug.LogError("ObjectContainer not found.");
            }

            replacedObjects.Add(collidedObject);

            StartCoroutine(DestroyObjectWithDelay(collidedObject));
        }
    }

    private IEnumerator DestroyObjectWithDelay(GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(objectToDestroy);
    }

    private IEnumerator StartReplacementCooldown()
    {
        yield return new WaitForSeconds(replacementCooldown);
        canReplace = true;
    }
}
