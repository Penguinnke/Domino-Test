using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSystem : MonoBehaviour
{
    private float rotationZ;
    public BoxCollider2D _boxCollider;
    public string _tagA_RIGHT = "TagA_RIGHT";
    public string _tagB_LEFT = "TagB_LEFT";
    public string _tagAA_RIGHT = "AA";
    public string _tagBB_LEFT = "BB";
    public string Untagged = "Untagged";
    public GameObject Black;
    public GameObject White;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>(); 
    }

    void Update()
    {
        rotationZ = transform.rotation.eulerAngles.z;
    }


    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Vector2 _colliderCenter = _boxCollider.bounds.center;
        Vector2 _colliderExtents = _boxCollider.bounds.extents;
        ContactPoint2D[] contacts = _collision.contacts;
        rotationZ = transform.rotation.eulerAngles.z;

        if (Mathf.Approximately(rotationZ, 0f))// Code to execute if the z-axis rotation is approximately 0 degrees
            {
            Debug.Log("The z-axis rotation is 0 degrees");

                foreach (ContactPoint2D contact in contacts) //i dont think anything is wrong with the foreach method so i'm confused
                {
                    if(contact.point.x > _colliderCenter.x)//Check if the contact point is on the right side of the collider
                    {
                            _collision.gameObject.tag = _tagA_RIGHT;
                            break;
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
                        _collision.gameObject.tag = _tagAA_RIGHT;
                        break; //Stop checking other contact points
                    }

                    if(contact.point.x < _colliderCenter.x)
                    {
                        _collision.gameObject.tag = _tagBB_LEFT;
                        break;
                    }
                }
            }

            if (Mathf.Approximately(rotationZ, 90f))// Code to execute if the z-axis rotation is approximately 90 degrees
            {
                Debug.Log("The z-axis rotation is 90 degrees");
                gameObject.tag = Untagged;

                
                // foreach (ContactPoint2D contact in contacts)
                // {
                //     if(contact.point.y > _colliderCenter.y)//Check if the contact point is above the collidercenter
                //     {
                //         _collision.gameObject.tag = Untagged;
                //         break; //Stop checking other contact points
                //     }

                //     if(contact.point.y < _colliderCenter.y)
                //     {
                //         _collision.gameObject.tag = Untagged;
                //         break;
                //     }
                // }
            }


            if (Mathf.Approximately(rotationZ, -90f))// Code to execute if the z-axis rotation is approximately -90 degrees
            {
                Debug.Log("The z-axis rotation is -90 degrees");
                gameObject.tag = Untagged;
            } 
    }
}
