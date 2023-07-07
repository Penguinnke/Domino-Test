using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingColliding : MonoBehaviour
{
    //The tag manager
    private float rotationZ;
    private BoxCollider2D _boxCollider;
    public string _tagA_RIGHT = "TagA_RIGHT";
    public string _tagB_LEFT = "TagB_LEFT";
    public string Untagged = "Untagged";
    public GameObject Black;
    public GameObject White;

    //For dragging the domino around
    public bool _dragging;
    private Vector2 _offset;

    private void Awake() 
    {
        _dragging = false;
        _boxCollider = GetComponent<BoxCollider2D>(); //Get the boxcollider for the tag manager
        //this.gameObject.GetComponent<TagSystem2>().enabled = false;
    }

    private void Update() 
    {
        rotationZ = transform.rotation.eulerAngles.z;//Get rotation Z
        Dragging();

        if (_dragging == false)
        {
            //gameObject.tag = "Domino";
            // Black.tag = _tagB_LEFT;
            // White.tag = _tagA_RIGHT;
            //this.gameObject.GetComponent<TagSystem2>().enabled = false;
        }

        if (_dragging == true) //So it doesn't go against the tagmanager
        {
            // Black.tag = Untagged;
            // White.tag = Untagged;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                transform.Rotate(0f, 0f, 90f);
            }

            //this.gameObject.GetComponent<TagSystem2>().enabled = true;
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
