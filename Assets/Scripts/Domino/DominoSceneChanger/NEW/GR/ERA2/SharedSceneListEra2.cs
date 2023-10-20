using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedSceneListEra2 : MonoBehaviour
{
    public static SharedSceneListEra2 Instance { get; private set; }

    public List<string> Scenes = new List<string>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}