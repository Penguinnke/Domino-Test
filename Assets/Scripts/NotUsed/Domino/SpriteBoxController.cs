using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SpriteBoxController  : MonoBehaviour
{
    private Vector2 boxSize;
    private Vector2 boxPosition;

    private void Start()
    {
        // Get the size and position of the box
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        boxSize = spriteRenderer.bounds.size;
        boxPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object entered the box
        Vector2 objectPosition = collision.transform.position;

        if (objectPosition.x >= boxPosition.x && objectPosition.x <= boxPosition.x + boxSize.x
            && objectPosition.y >= boxPosition.y && objectPosition.y <= boxPosition.y + boxSize.y)
        {
            // Object entered the box
            Debug.Log("Object entered the box!");
        }
    }
}