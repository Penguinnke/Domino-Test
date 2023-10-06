using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSystem : MonoBehaviour
{
    public GameObject Slot;
    private bool isDragging = false;
    private Vector2 initialPosition;
    private bool snapped = false; // Add a flag to track if the piece is snapped
    public string targetSceneName;

    private static int filledSlots = 0; // Keep track of filled slots
    public int totalSlots = 5; // Set the total number of slots

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !snapped) // Only allow dragging if not already snapped
        {
            isDragging = true;
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            SnapToSlotIfCloseEnough();
        }
    }

    private void Update()
    {
        if (isDragging && !snapped) // Only update position if not already snapped
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }

    private void SnapToSlotIfCloseEnough()
    {
        float distance = Vector2.Distance(transform.position, Slot.transform.position);

        if (distance <= 1.0f) // Adjust the threshold value as needed
        {
            transform.position = Slot.transform.position;
            snapped = true; // Set the snapped flag to true

            // Increment the filled slots count
            filledSlots++;
            Debug.Log(filledSlots);

            // Check if all slots are filled
            if (filledSlots == totalSlots)
            {
                SceneManager.LoadScene(targetSceneName);

                // Reset the filledSlots count
                filledSlots = 0;
            }
        }
        else
        {
            transform.position = initialPosition; // Return to the initial position if not close enough
        }
    }
}