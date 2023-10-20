using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveWithCamera : MonoBehaviour
{
    public Transform cameraReference;
    private Vector3 offset;
    private BoxCollider2D boxCollider;

    void Start()
    {
        offset = transform.position - cameraReference.position;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void LateUpdate()
    {
        Vector3 targetPosition = cameraReference.position + offset;
        transform.position = targetPosition;

        if (Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("w"))
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
        }
    }
}
