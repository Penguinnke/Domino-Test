using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSound : MonoBehaviour
{
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}