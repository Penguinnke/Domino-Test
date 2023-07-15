using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag2 : MonoBehaviour
{
   private bool _dragging, _placed;
    private Vector2 _offset, _orginalPosition;

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
}
