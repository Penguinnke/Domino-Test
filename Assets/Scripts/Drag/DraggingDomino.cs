using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingDomino : MonoBehaviour
{
    public bool _dragging, _placed;

    private Vector2 _offset, _orginalPosition;

    private void Start() {
        _placed = false;
    }
    private void Awake() {
        _orginalPosition = transform.position;
    }

    private void Update() {
        if(!_dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;

        // if (_dragging == true)
        // {
        //     UnfreezeXY();
        // }

        // if (_placed == true)
        // {
        //     gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        // }
    }

    private void OnMouseDown() {
        _dragging = true;
        _placed = false;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp() {
        _dragging = false;
        _placed = false;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // private void UnfreezeXY() {
    //     gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
    //     gameObject.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    //     _dragging = true;       
    // }

}