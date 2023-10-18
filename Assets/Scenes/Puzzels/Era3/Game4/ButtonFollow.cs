using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFollow : MonoBehaviour
{
    public Transform playerTransform; 
    public Vector2 offset;           

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 targetPosition = playerTransform.position + new Vector3(offset.x, offset.y, 0f);
            transform.position = targetPosition - cameraPosition;
        }
    }
}