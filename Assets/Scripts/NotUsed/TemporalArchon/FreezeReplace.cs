using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeReplace : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
            // Prevent further movement
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
    }
}
