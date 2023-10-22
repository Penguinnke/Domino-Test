using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAndOff : MonoBehaviour
{
    public GameObject objectToToggle;
    public float onDuration = 15.0f; // Time in seconds the object stays on
    public float minOffDuration = 10.0f; // Minimum time in seconds the object stays off
    public float maxOffDuration = 25.0f; // Maximum time in seconds the object stays off
    private bool isObjectActive = false;

    private void Start()
    {
        isObjectActive = objectToToggle.activeSelf;
        StartCoroutine(ToggleObjectWithDurations());
    }

    private IEnumerator ToggleObjectWithDurations()
    {
        while (true)
        {
            if (isObjectActive)
            {
                // If the object is currently active, wait for the onDuration and then deactivate it.
                yield return new WaitForSeconds(onDuration);
                isObjectActive = false;
                objectToToggle.SetActive(false);
            }
            else
            {
                // If the object is currently inactive, generate a random offDuration and then activate it.
                float randomOffDuration = Random.Range(minOffDuration, maxOffDuration);
                yield return new WaitForSeconds(randomOffDuration);
                isObjectActive = true;
                objectToToggle.SetActive(true);
            }
        }
    }
}