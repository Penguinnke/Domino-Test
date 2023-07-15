using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSystem3 : MonoBehaviour
{
    public string tagA_Right = "_tagA_RIGHT";
    public string tagB_Left = "_tagB_LEFT";
    public string tagC_Up = "_tagC_UP";
    public string tagD_Down = "_tagD_DOWN";

    private BoxCollider2D _boxCollider;
    private float rotationZ;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 colliderCenter = _boxCollider.bounds.center;
        Vector2 colliderExtents = _boxCollider.bounds.extents;
        ContactPoint2D[] contacts = collision.contacts;
        rotationZ = transform.rotation.eulerAngles.z;

        if (Mathf.Approximately(rotationZ, 0f)) // Domino is at 0 degrees
        {
            Debug.Log("The z-axis rotation is 0 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                Vector2 contactPoint = contact.point;

                if (contactPoint.x < colliderCenter.x) // Collided from the left side
                {
                    gameObject.tag = tagB_Left;
                    break;
                }
                else if (contactPoint.x > colliderCenter.x) // Collided from the right side
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

                if (contactPoint.x < colliderCenter.x) // Collided from the left side
                {
                    gameObject.tag = tagA_Right;
                    break;
                }
                else if (contactPoint.x > colliderCenter.x) // Collided from the right side
                {
                    gameObject.tag = tagB_Left;
                    break;
                }
            }
        }
        else if (Mathf.Approximately(rotationZ, 90f)) // Domino is at 90 degrees
        {
            Debug.Log("The z-axis rotation is 90 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                Vector2 contactPoint = contact.point;

                if (contactPoint.y < colliderCenter.y) // Collided from the down side
                {
                    gameObject.tag = tagD_Down;
                    break;
                }
                else if (contactPoint.y > colliderCenter.y) // Collided from the up side
                {
                    gameObject.tag = tagC_Up;
                    break;
                }
            }
        }
        else if (Mathf.Approximately(rotationZ, -90f) || Mathf.Approximately(rotationZ, 270f)) // Domino is at -90 degrees or 270 degrees
        {
            Debug.Log("The z-axis rotation is -90 degrees");

            foreach (ContactPoint2D contact in contacts)
            {
                Vector2 contactPoint = contact.point;

                if (contactPoint.y < colliderCenter.y) // Collided from the up side
                {
                    gameObject.tag = tagC_Up;
                    break;
                }
                else if (contactPoint.y > colliderCenter.y) // Collided from the down side
                {
                    gameObject.tag = tagD_Down;
                    break;
                }
            }
        }
    }
}