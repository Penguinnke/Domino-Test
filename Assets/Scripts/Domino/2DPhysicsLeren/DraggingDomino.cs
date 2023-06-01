using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingDomino : MonoBehaviour
{
    public bool _dragging, _placed;

    private Vector2 _offset;


    private void Awake() {
        _placed = false;
    }

    private void Update() {
        if(!_dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
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

}
