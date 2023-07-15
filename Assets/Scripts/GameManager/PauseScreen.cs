using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject PauseScreen_;
    //Scripts
    public CameraController cameraController;
    public ChangeImage changeImage;
    public CopyAndEnableObject copyandenableObject;
    public DominoReplacement dominoReplacement;
    //bools
    private bool isActive;
    private bool isScriptEnabled;

    private void Start()
    {
        // Initially deactivate the target object and make sure the script for the camera is on 
        PauseScreen_.SetActive(false);
        //scripts
        cameraController.enabled = true;
        changeImage.enabled = true;
        copyandenableObject.enabled = true;
        dominoReplacement.enabled = true;
        isActive = false; //pausescreen
        isScriptEnabled = true; //scripts
    }

    private void Update()
    {
        // Check for the Esc key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the active state of the target object
            isActive = !isActive;
            PauseScreen_.SetActive(isActive);

            // Toggle the enabled state of the target script
            isScriptEnabled = !isScriptEnabled;
            cameraController.enabled = isScriptEnabled;
            changeImage.enabled = isScriptEnabled;
            copyandenableObject.enabled = isScriptEnabled;
            dominoReplacement.enabled = isScriptEnabled;
        }
    }
}