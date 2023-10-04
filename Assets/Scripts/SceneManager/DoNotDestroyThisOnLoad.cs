using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyThisOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // Ensure that this GameObject persists between scene changes.
        DontDestroyOnLoad(gameObject);
    }
}
