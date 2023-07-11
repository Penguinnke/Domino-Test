using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalArchon : MonoBehaviour
{
    public Transform cameraTransform;

    public void MoveCameraToPosition(Transform targetObject)
    {
        cameraTransform.position = targetObject.TransformPoint(new Vector3(-0.13f, 0f, 0f));
    }
}
