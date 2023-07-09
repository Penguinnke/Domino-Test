using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;   // Adjust the movement speed as needed
    public float zoomSpeed = 5f;   // Adjust the zoom speed as needed
    public float minZoom = 2f;     // Adjust the minimum zoom level
    public float maxZoom = 10f;    // Adjust the maximum zoom level
    public float minX = -10f;      // Adjust the minimum x-coordinate limit
    public float maxX = 10f;       // Adjust the maximum x-coordinate limit
    public float minY = -5f;       // Adjust the minimum y-coordinate limit
    public float maxY = 5f;        // Adjust the maximum y-coordinate limit

    void Update()
    {
        // Camera movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;

        // Clamp the new position within the desired limits
        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition.x = clampedX;
        newPosition.y = clampedY;

        transform.position = newPosition;

        // Camera zooming
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float zoomAmount = scrollInput * zoomSpeed * Time.deltaTime;
        ZoomCamera(zoomAmount);

        // Reset camera position on Backspace key press
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }
    }

    void ZoomCamera(float zoomAmount)
    {
        Camera camera = GetComponent<Camera>();

        // Calculate the new zoom level
        float newZoom = camera.orthographicSize - zoomAmount;
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        // Apply the new zoom level to the camera
        camera.orthographicSize = newZoom;
    }
}


