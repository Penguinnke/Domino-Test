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
        _dragging = false; //At the beginning the domino is not getting dragged yet
        _boxCollider = GetComponent<BoxCollider2D>(); //Get the boxcollider for the tag manager
    }

    private void Update() 
    {
        rotationZ = transform.rotation.eulerAngles.z;//Get rotation Z
        Dragging();

        if (_dragging == false)
        {
            gameObject.tag = Untagged;
            Black.tag = _tagB_LEFT;
            White.tag = _tagA_RIGHT;
        }

        if (_dragging == true) //So it doesn't go against the tagmanager
        {
            Black.tag = Untagged;
            White.tag = Untagged;

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

    private void OnCollisionEnter2D(Collision2D _collision)
    {
            Vector2 _colliderCenter = _boxCollider.bounds.center;//Calculate the center of the collider
            Vector2 _colliderExtents = _boxCollider.bounds.extents;//Calculate the extens of the collider
            ContactPoint2D[] contacts = _collision.contacts;//Get the contact points of the collision
            rotationZ = transform.rotation.eulerAngles.z;//Get rotation Z

            if (Mathf.Approximately(rotationZ, 0f))// Code to execute if the z-axis rotation is approximately 0 degrees
            {
            Debug.Log("The z-axis rotation is 0 degrees");

                foreach (ContactPoint2D contact in contacts)
                {
                    if(contact.point.x > _colliderCenter.x)//Check if the contact point is on the right side of the collider
                    {
                        _collision.gameObject.tag = _tagA_RIGHT;
                        break; //Stop checking other contact points
                    }

                    if(contact.point.x < _colliderCenter.x)
                    {
                        _collision.gameObject.tag = _tagB_LEFT;//Assign tagB to the colliding object if it was not assigned tagA
                        break;
                    }
                }
            }

            if (Mathf.Approximately(rotationZ, 180f))// Code to execute if the z-axis rotation is approximately 180 degrees
            {
            Debug.Log("The z-axis rotation is 180 degrees");

                foreach (ContactPoint2D contact in contacts)
                {
                    //Check if the contact point is on the right side of the collider
                    if(contact.point.x > _colliderCenter.x)
                    {
                        _collision.gameObject.tag = _tagB_LEFT;
                        break; //Stop checking other contact points
                    }

                    if(contact.point.x < _colliderCenter.x)
                    {
                        _collision.gameObject.tag = _tagA_RIGHT;
                        break;
                    }
                }
            }


            if (Mathf.Approximately(rotationZ, 90f))// Code to execute if the z-axis rotation is approximately 90 degrees
            {
            Debug.Log("The z-axis rotation is 90 degrees");

                foreach (ContactPoint2D contact in contacts)
                {
                    if(contact.point.y > _colliderCenter.y)//Check if the contact point is above the collidercenter
                    {
                        _collision.gameObject.tag = _tagA_RIGHT;
                        break; //Stop checking other contact points
                    }

                    if(contact.point.y < _colliderCenter.y)
                    {
                        _collision.gameObject.tag = _tagB_LEFT;
                        break;
                    }
                }
            }


            if (Mathf.Approximately(rotationZ, -90f))// Code to execute if the z-axis rotation is approximately -90 degrees
            {
            Debug.Log("The z-axis rotation is -90 degrees");

                foreach (ContactPoint2D contact in contacts)
                {
                    if(contact.point.y > _colliderCenter.y)//Check if the contact point is above the collidercenter
                    {
                        _collision.gameObject.tag = _tagB_LEFT;
                        break; //Stop checking other contact points
                    }

                    if(contact.point.y < _colliderCenter.y)
                    {
                        _collision.gameObject.tag = _tagA_RIGHT;
                        break;
                    }
                }
            }          
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
