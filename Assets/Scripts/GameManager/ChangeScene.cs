using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string targetSceneName; // The name of the scene you want to switch to

    public void SceneChanger()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}