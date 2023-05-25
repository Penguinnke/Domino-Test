using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Drag4 : MonoBehaviour
{

    private GameObject targetTransform; // Reference to the object you want to stick to
    private Transform targetObject; 

    
    public float stickDistance = 1f; // Distance from the target object's side

    public string _dominoTag = "Domino1";

    private void Start() 
    {
        targetTransform = GameObject.FindGameObjectWithTag(_dominoTag);
        targetObject = targetTransform.GetComponent<Transform>();
    }
    
    private void OnCollisionEnter2D(Collision2D _collision) 
    {
        if (_collision.gameObject.tag == _dominoTag)
        {
            Debug.Log("Collision 1!");
            CalculatePos(); // Calculate the position on the side of the target object
            _collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        
        } else {
            Debug.Log("No");
        }
    } 

    private void UnfreezeXY()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }

    private void CalculatePos()
    {
        Vector2 targetPosition = (Vector2)targetObject.position + (Vector2)targetObject.right * stickDistance;
        transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }
    
    
}