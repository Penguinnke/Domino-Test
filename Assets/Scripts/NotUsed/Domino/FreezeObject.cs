using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObject : MonoBehaviour
{
    private Vector3 frozenPosition;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        frozenPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = frozenPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Prevent other objects from passing through
        collision.collider.isTrigger = false;
        
        // Set the sorting order to render in front
        if (collision.gameObject.TryGetComponent(out SpriteRenderer otherRenderer))
        {
            int maxSortingOrder = Mathf.Max(spriteRenderer.sortingOrder, otherRenderer.sortingOrder);
            spriteRenderer.sortingOrder = maxSortingOrder + 1;
        }
    }
}