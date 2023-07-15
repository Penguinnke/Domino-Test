using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPart3 : MonoBehaviour
{
    public GameObject Domino1; 
    public GameObject Domino2; 
    public GameObject Domino3; 
    public GameObject TemporalArchonPush;
    public GameObject MoveCamera;
    public GameObject ControlScreen;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Domino1 || collision.gameObject == Domino2 || collision.gameObject == Domino3)
        {   
            TemporalArchonPush.SetActive(false);
            MoveCamera.SetActive(true);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveCamera.SetActive(false);
            ControlScreen.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ControlScreen.SetActive(false);
        }
    }
}
