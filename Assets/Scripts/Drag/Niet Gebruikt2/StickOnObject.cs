using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnObject : MonoBehaviour
{
    public Rigidbody2D rb; // Reference to the Rigidbody2D component of the object
    public GameObject StickTo; // Tag of the object to stick to

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == StickTo)
        {
            // Make the object stick to the target object by disabling its Rigidbody2D
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.parent = collision.transform; // Attach the object to the target object as a child
        }
    }
}
