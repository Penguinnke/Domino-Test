using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickVersionD : MonoBehaviour
{
    private bool isStuck = false;
    private GameObject targetObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isStuck && collision.gameObject.CompareTag("Pickupable"))
        {
            isStuck = true;
            targetObject = collision.gameObject;
            StickToSide();
        }
    }

    private void StickToSide()
    {
        // Calculate the offset based on the colliders
        float xOffset = GetComponent<Collider2D>().bounds.extents.x + targetObject.GetComponent<Collider2D>().bounds.extents.x;
        Vector2 targetPosition = targetObject.transform.position + new Vector3(xOffset, 0f, 0f);
        
        // Set the object's position to stick to the side
        transform.position = targetPosition;

        // Attach the object to the target as a child
        transform.SetParent(targetObject.transform);
    }
}

