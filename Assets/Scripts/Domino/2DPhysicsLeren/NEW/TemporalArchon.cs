using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalArchon : MonoBehaviour
{
    public Transform cameraTransform;

    public void MoveCameraToPosition()
    {
        Vector3 targetPosition = new Vector3(-0.13f, 0f, cameraTransform.position.z);
        cameraTransform.position = targetPosition;
    }
}