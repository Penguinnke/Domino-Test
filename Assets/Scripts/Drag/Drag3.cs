using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Drag3 : MonoBehaviour
{
    private bool _dragging, _placed;

    private Vector2 _offset, _orginalPosition;

    // [SerializeField]
    // public List<Transform> targetObject;

    private GameObject targetTransform;
    private Transform targetObject;

    //public Transform targetObject; // Reference to the object you want to stick to
    
    public float stickDistance = 1f; // Distance from the target object's side

    public string _dominoTag = "Domino1";

    private void Start() 
    {
        targetTransform = GameObject.FindGameObjectWithTag(_dominoTag);
        targetObject = targetTransform.GetComponent<Transform>();

    }

    private void Awake() 
    {
        _orginalPosition = transform.position;
    }

    private void Update() {
        if(!_dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;

        //define the detection area
        Vector2 center = transform.position;
        Vector2 size = targetObject.GetComponent<SpriteRenderer>().bounds.size;

        //Check if any colliders overlap with the detection area
        Collider2D[] colliders = Physics2D.OverlapAreaAll(center - size / 30f, center + size / 30f);

        //Loop through the detected colliders 
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject && collider.gameObject == targetObject.gameObject)
            {
                //Collision with the target block detected
                Debug.Log("Collision detected with the target");
                //Perform action here
                // Calculate the position on the side of the target object
                Vector2 targetPosition = (Vector2)targetObject.position + (Vector2)targetObject.right * stickDistance;
                transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);               
            }
        }


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

    // private void OnCollisionEnter2D(Collision2D _collision) 
    // {
    //     if (_collision.gameObject.tag == _dominoTag)
    //     {
    //         Debug.Log("Collision 1!");
    //         // Calculate the position on the side of the target object
    //         Vector2 targetPosition = (Vector2)targetObject.position + (Vector2)targetObject.right * stickDistance;
    //         transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    //     } else {
    //         Debug.Log("No");
    //     }
    // } 
    
}

