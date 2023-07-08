using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;   // Adjust the movement speed as needed
    public float zoomSpeed = 5f;   // Adjust the zoom speed as needed
    public float minZoom = 2f;     // Adjust the minimum zoom level
    public float maxZoom = 10f;    // Adjust the maximum zoom level

    void Update()
    {
        // Camera movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Camera zooming
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float zoomAmount = scrollInput * zoomSpeed * Time.deltaTime;
        ZoomCamera(zoomAmount);
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