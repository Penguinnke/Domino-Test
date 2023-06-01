using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trying to make the Domino's stick again eachother while being able to drag it
//I used freeze constraints because they need to be able to drag it again if i pick it up again
//probably need to make a stick on function which i can turn off and on
public class Drag : MonoBehaviour
{

    private bool _dragging, _placed;
    private Vector2 _offset, _orginalPosition;
    public string _dominoTag = "Domino1";
    public string _dominoTag2 = "Domino2";

    

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

    private void OnCollisionEnter2D(Collision2D _collision) 
    {
        if (_collision.gameObject.tag == _dominoTag) //both game objects have different tags
        {
            Debug.Log("Collision 1!");
            _collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }

        if (_collision.gameObject.tag == _dominoTag2) //the freeze constraints only work on the other object it refers to and not to the object the script is ons 
        {
            Debug.Log("Collision 2!");
            _collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        }
    }

}
