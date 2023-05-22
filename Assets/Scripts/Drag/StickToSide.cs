using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToSide : MonoBehaviour
{
    public Transform targetObject; // Reference to the object you want to stick to

    public float stickDistance = 1f; // Distance from the target object's side

    private void Update()
    {
        // Calculate the position on the side of the target object
        Vector2 targetPosition = (Vector2)targetObject.position + (Vector2)targetObject.right * stickDistance;

        // Smoothly move the object towards the target position using Lerp
        transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }
}
