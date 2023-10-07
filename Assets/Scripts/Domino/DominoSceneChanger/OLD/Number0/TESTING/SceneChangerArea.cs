using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneChangerArea
{
    public bool isActive = true;
    public List<string> scenes;
    public Vector3 center;
    public Vector3 size;
    public float delayInSeconds = 8f;
    public string endingScene = "EndingScene";
}