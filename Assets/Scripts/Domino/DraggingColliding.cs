using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingColliding : MonoBehaviour
{
    //The tag manager
    private float rotationZ;
    private BoxCollider2D _boxCollider;

    //For dragging the domino around
    public bool _dragging;
    private Vector2 _offset;

    private void Awake() 
    {
        _dragging = false;
        _boxCollider = GetComponent<BoxCollider2D>(); //Get the boxcollider for the tag manager
    }

    private void Update() 
    {
        rotationZ = transform.rotation.eulerAngles.z;//Get rotation Z
        Dragging();

        if (_dragging == true) //So it doesn't go against the tagmanager
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                transform.Rotate(0f, 0f, 90f);
            }
        }
    }

    private void OnMouseDown()
    {
        PickedUp();
    }

    private void OnMouseUp()
    {
        LetGo();
    }
    
    private void Dragging()//Dragging the domino around
    {
        if (!_dragging) return;
        var mousePosition = GetMousePos();
        transform.position = mousePosition - _offset;
    }

    private void PickedUp()//Picking up the domino
    {
        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    private void LetGo()//Letting go of the domino
    {
        _dragging = false;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    Vector2 GetMousePos()//Getting the mouseposition
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
