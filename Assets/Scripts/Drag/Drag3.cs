using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag3 : MonoBehaviour
{
    private bool _dragging, _placed;
    private Vector2 _offset, _orginalPosition;
    public Transform targetObject; // Reference to the object you want to stick to
    public float stickDistance = 1f; // Distance from the target object's side
    public string _dominoTag = "Domino1";

    private void Awake() 
    {
        _orginalPosition = transform.position;
    }

    private void Update() {
        if(!_dragging) return; //I think it can't detect collision because of this line but if I delete this line it will not freeze the constraints :(
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;

    }

    private void OnMouseDown()
    {
        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp() 
    {
        _dragging = false;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    //  private void OnCollisionEnter2D(Collision2D _collision) 
    // {
    //     if (_collision.gameObject.tag == _dominoTag) 
    //     {
    //         Debug.Log("Collision 1!");
    //         // Calculate the position on the side of the target object
    //         // Vector2 targetPosition = (Vector2)targetObject.position + (Vector2)targetObject.right * stickDistance;
    //         // transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    //         //_collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected!");
        // Perform actions or logic when a collision occurs
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Ongoing!");
        // Perform actions or logic while the collision is ongoing
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Ended!");
        // Perform actions or logic when the collision ends
    }

    
}

