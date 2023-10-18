using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject Button; 
    public Animator animator; 
    public GameObject Bridge;
    public GameObject Floor;

    private bool isPlayerNear = false;
    private bool isLeverOn = false; 
    private bool isFloorOn = true;

    private void Update()
    {
        if (isPlayerNear) 
        {
            Button.SetActive(true);
            if (Button.activeSelf && Input.GetMouseButtonDown(0))
            {
                isLeverOn = !isLeverOn;
                animator.SetBool("LeverOn", isLeverOn);
                Bridge.SetActive(isLeverOn);
                isFloorOn = !isFloorOn; 
                Floor.SetActive(isFloorOn);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerNear = false;
            Button.SetActive(false); 
        }
    }
}
