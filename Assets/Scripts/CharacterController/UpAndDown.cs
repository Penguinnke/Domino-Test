using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    public Animator animator;
    public float speed = 5.0f; // Adjust the movement speed as needed

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        // Move the GameObject
        transform.position = newPosition;

        animator.SetFloat("Speed", 0f);
        animator.SetFloat("Horizontal", 0f);
        animator.SetFloat("Vertical", 0f);

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("Horizontal", -1f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Speed", 1f);
        } 

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Horizontal", 1f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Speed", 1f);
        } 

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 1f);
            animator.SetFloat("Speed", 1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", -1f);
            animator.SetFloat("Speed", 1f);
        } 
    }
}

