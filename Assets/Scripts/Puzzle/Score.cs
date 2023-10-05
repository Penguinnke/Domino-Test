using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves a specific tag (e.g., "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Increase the score by one
            score++;

            // Turn off the object that this script is attached to
            gameObject.SetActive(false);
        }
    }
}