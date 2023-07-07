using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSystem3 : MonoBehaviour
{
    public string tagA_Right = "_tagA_RIGHT";
    public string tagB_Left = "_tagB_LEFT";
    private BoxCollider2D _boxCollider;
    private float rotationZ;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Vector2 _colliderCenter = _boxCollider.bounds.center;
        Vector2 _colliderExtents = _boxCollider.bounds.extents;
        ContactPoint2D[] contacts = _collision.contacts;
        rotationZ = transform.rotation.eulerAngles.z;

        if (Mathf.Approximately(rotationZ, 0f)) // Domino is at 0 degrees
        {
            Debug.Log("The z-axis rotation is 0 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                Vector2 contactPoint = contact.point;

                if (contactPoint.x < _colliderCenter.x) // Collided from the left side
                {
                    gameObject.tag = tagB_Left;
                    break;
                }
                else if (contactPoint.x > _colliderCenter.x) // Collided from the right side
                {
                    gameObject.tag = tagA_Right;
                    break;
                }
            }
        }
        else if (Mathf.Approximately(rotationZ, 180f)) // Domino is at 180 degrees
        {
            Debug.Log("The z-axis rotation is 180 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                Vector2 contactPoint = contact.point;

                if (contactPoint.x < _colliderCenter.x) // Collided from the left side
                {
                    gameObject.tag = tagA_Right;
                    break;
                }
                else if (contactPoint.x > _colliderCenter.x) // Collided from the right side
                {
                    gameObject.tag = tagB_Left;
                    break;
                }
            }
        }
    }
}