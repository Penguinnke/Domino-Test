using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SoldierMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 5.0f; // Adjust the movement speed as needed
    public Transform attackPosition; // Public variable for the attack position
    public float attackRadius = 1.0f; // Radius for the attack
    
    // Cooldown variables
    public float attackCooldown = 1.0f; // The time between attacks
    private float lastAttackTime;
    public GameObject slime;
    public string WinScreen;

    //Win condition
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        // Initialize the last attack time to allow immediate attack
        lastAttackTime = -attackCooldown;
        UpdateScoreText();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {
                animator.SetFloat("ForwardAttack", 1f);
                animator.SetFloat("BackwardsAttack", 0f);
            }

        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;

        // Define the minimum and maximum x positions
        float minX = -6.0f; // Change this value to your desired minimum x position
        float maxX = 7.96f;  // Change this value to your desired maximum x position

        // Clamp the new position within the specified range
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Move the GameObject
        transform.position = newPosition;

        // Check if the left mouse button is pressed and if enough time has passed since the last attack
        bool isAttacking = Input.GetMouseButtonDown(0) && (Time.time - lastAttackTime >= attackCooldown);

        // Set the "Attack" parameter based on the input
        if (isAttacking)
        {
            // Update the last attack time
            lastAttackTime = Time.time;

            // Check for enemies within the attack radius
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRadius);

            // Deal damage to enemies
            foreach (Collider2D enemy in enemiesToDamage)
            {
                Debug.Log("Hit");
                SlimeMovement enemySlimeMovement = enemy.GetComponent<SlimeMovement>();

                score++;
                UpdateScoreText();

                if (score >= 20)
                {
                    SceneManager.LoadScene(WinScreen);
                }

                if (enemySlimeMovement != null)
                {
                    // Call the "Death" function on the enemy's script
                    enemySlimeMovement.Death();
                    
                    // Check if 'slime' is not null before instantiating
                    if (slime != null)
                    {
                        Vector3 spawnPoint = new Vector3(9.27f, -3.87f, 0f);
                        Instantiate(slime, spawnPoint, Quaternion.identity);
                    }
                }
            }

            if (horizontalInput > 0)
            {
                // If moving forward (D key), set the "ForwardAttack" parameter
                animator.SetFloat("ForwardAttack", 1f);
                animator.SetFloat("BackwardsAttack", 0f);
            }
            else if (horizontalInput < 0)
            {
                // If moving backward (A key), set the "BackwardsAttack" parameter
                animator.SetFloat("ForwardAttack", 0f);
                animator.SetFloat("BackwardsAttack", 1f);
            }
        }

        else
        {
            // If not attacking or cooldown is active, set both attack parameters to 0
            animator.SetFloat("ForwardAttack", 0f);
            animator.SetFloat("BackwardsAttack", 0f);
        }

        // Check movement input and set animation parameters for walking
        if (horizontalInput > 0)
        {
            animator.SetFloat("Backwards", 0f);
            animator.SetFloat("Forward", 1f);
            animator.SetFloat("Speed", 1f);
        }
        else if (horizontalInput < 0)
        {
            animator.SetFloat("Backwards", 1f);
            animator.SetFloat("Forward", 0f);
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            // No horizontal input, character is idle
            animator.SetFloat("Backwards", 0f);
            animator.SetFloat("Forward", 0f);
            animator.SetFloat("Speed", 0f);
        }
    }

    // Draw gizmos for the attack radius in the Unity editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRadius);
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Win Score: " + score.ToString() + "/20";
        }
    }
}
