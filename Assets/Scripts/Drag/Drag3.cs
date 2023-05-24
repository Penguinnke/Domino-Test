using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Drag3 : MonoBehaviour
{
    private bool _dragging, _placed;

    private Vector2 _offset, _orginalPosition;

    private GameObject targetTransform; // Reference to the object you want to stick to
    private Transform targetObject; 

    public BoxCollider2D boxCollider2D;
    public float XSizeBC_A = 5; //before colliding
    public float YSizeBC_A = 5;

    public float XSizeBC_B = 5; //after colliding
    public float YSizeBC_B = 5;

    
    public float stickDistance = 1f; // Distance from the target object's side

    public string _dominoTag = "Domino1";

    private void Start() 
    {
        targetTransform = GameObject.FindGameObjectWithTag(_dominoTag);
        targetObject = targetTransform.GetComponent<Transform>();

        // Call the ChangeSize method with the desired size
        Vector2 newSize = new Vector2(XSizeBC_A, YSizeBC_A);
        ChangeSize(newSize);
    }

    private void Awake() 
    {
        _orginalPosition = transform.position;
    }

    private void Update() {
        if(!_dragging) return;
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
        FreezeXY();
        
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionEnter2D(Collision2D _collision) 
    {
        if (_collision.gameObject.tag == _dominoTag)
        {
            Debug.Log("Collision 1!");
            _dragging = false;
            CalculatePos(); // Calculate the position on the side of the target object
            _collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        
            // Call the ChangeSize method with the desired size
            Vector2 newSize = new Vector2(XSizeBC_B, YSizeBC_B);
            ChangeSize(newSize);
        
        } else {
            Debug.Log("No");
            _dragging = false;
        }
    } 

    private void FreezeXY()
    {
        gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }

    private void CalculatePos()
    {
        Vector2 targetPosition = (Vector2)targetObject.position + (Vector2)targetObject.right * stickDistance;
        transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
    }

    private void ChangeSize(Vector2 newSize)
    {
        boxCollider2D.size = newSize;
    }
    
    
}

