using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopColliderMovement : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Set the position of the collider to the contact point of the collision
        Vector2 contactPoint = collision.GetContact(0).point;
        boxCollider.transform.position = contactPoint;
    }
}
