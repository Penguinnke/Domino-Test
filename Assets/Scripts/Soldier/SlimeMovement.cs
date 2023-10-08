using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class SlimeMovement : MonoBehaviour
{
    public float minMoveSpeed = 6.0f; // Minimum move speed
    public float maxMoveSpeed = 8.0f; // Maximum move speed
    public int score = 10; // Public integer to keep track of the score
    private Rigidbody2D rb;
    private float moveSpeed; // Declare moveSpeed here
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro object in the Inspector
    public Animator animator;
    public ScoringSystem scoringSystem;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Generate a random moveSpeed within a specified range
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        rb.velocity = new Vector2(-moveSpeed, 0);

        // Initialize the score text (assuming you've assigned the ScoringSystem GameObject in the Inspector)
        scoringSystem = FindObjectOfType<ScoringSystem>();
    }

    // You can add other functionality here as needed

    private void Update()
    {
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        
        // Check if the object is off-screen
        if (transform.position.x < Camera.main.transform.position.x - cameraWidth)
        {
            // Increment the score by 10
            scoringSystem.DecreaseScore(1);

            // Calculate the new position based on the camera width
            Vector3 newPosition = transform.position;
            newPosition.x = Camera.main.transform.position.x + cameraWidth;
            transform.position = newPosition;

            scoringSystem.UpdateScoreDisplay();
        }
    }

    public void Death()
    {
    animator.SetBool("Death", true);
    StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
    // Wait for the animation to finish
    yield return new WaitForSeconds(0.7f);

    // Destroy the game object
    Destroy(gameObject);
    }
}
