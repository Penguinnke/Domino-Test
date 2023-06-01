using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCDivider : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    public string _tagA = "TagA_RIGHT";
    public string _tagB = "TagB_LEFT";

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

        foreach (ContactPoint2D contact in contacts)
        {
            //Check if the contact point is on the right side of the collider
            if(contact.point.x > _colliderCenter.x)
            {
                _collision.gameObject.tag = _tagA;
                break; //Stop checking other contact points
            }

            //Assign tagB to the colliding object if it was not assigned tagA
            if(contact.point.x < _colliderCenter.x)
            {
            _collision.gameObject.tag = _tagB;
            }
        }


    }
}
