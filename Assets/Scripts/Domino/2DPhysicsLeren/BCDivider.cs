using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCDivider : MonoBehaviour
{
    private float rotationZ;
    private BoxCollider2D _boxCollider;

    public string _tagA_RIGHT = "TagA_RIGHT";
    public string _tagB_LEFT = "TagB_LEFT";

    private void Awake() 
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D _collision) 
    {
        //Calculate the center and extens of the collider
        Vector2 _colliderCenter = _boxCollider.bounds.center;
        Vector2 _colliderExtents = _boxCollider.bounds.extents;

        //Get the contact points of the collision
        ContactPoint2D[] contacts = _collision.contacts;
        rotationZ = transform.rotation.eulerAngles.z;

        if (Mathf.Approximately(rotationZ, 0f))
        {
        // Code to execute if the z-axis rotation is approximately 0 degrees
        Debug.Log("The z-axis rotation is 0 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                //Check if the contact point is on the right side of the collider
                if(contact.point.x > _colliderCenter.x)
                {
                    _collision.gameObject.tag = _tagA_RIGHT;
                    break; //Stop checking other contact points
                }

                //Assign tagB to the colliding object if it was not assigned tagA
                if(contact.point.x < _colliderCenter.x)
                {
                    _collision.gameObject.tag = _tagB_LEFT;
                    break;
                }
            }
        }

        if (Mathf.Approximately(rotationZ, 180f))
        {
        // Code to execute if the z-axis rotation is approximately 180 degrees
        Debug.Log("The z-axis rotation is 180 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                //Check if the contact point is on the right side of the collider
                if(contact.point.x > _colliderCenter.x)
                {
                    _collision.gameObject.tag = _tagB_LEFT;
                    break; //Stop checking other contact points
                }

                //Assign tagB to the colliding object if it was not assigned tagA
                if(contact.point.x < _colliderCenter.x)
                {
                    _collision.gameObject.tag = _tagA_RIGHT;
                    break;
                }
            }
        }


        if (Mathf.Approximately(rotationZ, 90f))
        {
        // Code to execute if the z-axis rotation is approximately 90 degrees
        Debug.Log("The z-axis rotation is 90 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                //Check if the contact point is above the collidercenter
                if(contact.point.y > _colliderCenter.y)
                {
                    _collision.gameObject.tag = _tagA_RIGHT;
                    break; //Stop checking other contact points
                }

                //Assign tagB to the colliding object if it was not assigned tagA
                if(contact.point.y < _colliderCenter.y)
                {
                    _collision.gameObject.tag = _tagB_LEFT;
                    break;
                }
            }
        }


        if (Mathf.Approximately(rotationZ, -90f))
        {
        // Code to execute if the z-axis rotation is approximately -90 degrees
        Debug.Log("The z-axis rotation is -90 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                //Check if the contact point is above the collidercenter
                if(contact.point.y > _colliderCenter.y)
                {
                    _collision.gameObject.tag = _tagB_LEFT;
                    break; //Stop checking other contact points
                }

                //Assign tagB to the colliding object if it was not assigned tagA
                if(contact.point.y < _colliderCenter.y)
                {
                    _collision.gameObject.tag = _tagA_RIGHT;
                    break;
                }
            }
        }
    }
}
