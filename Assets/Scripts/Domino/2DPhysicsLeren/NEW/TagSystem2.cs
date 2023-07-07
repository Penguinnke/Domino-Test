using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSystem2 : MonoBehaviour
{
    public BoxCollider2D _boxCollider;
    public string _tagA_RIGHT = "TagA_RIGHT";
    public string _tagB_LEFT = "TagB_LEFT";

    private Vector2[] _localColliderPoints;

    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _localColliderPoints = GetLocalColliderPoints();
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Vector2 _colliderCenter = _boxCollider.bounds.center;
        float rotationZ = transform.rotation.eulerAngles.z;

        Vector2[] localContactPoints = GetLocalContactPoints(_collision);

        foreach (Vector2 localContactPoint in localContactPoints)
        {
            bool isRightSide = IsRightSide(localContactPoint, rotationZ);

            if (isRightSide)
            {
                _collision.gameObject.tag = _tagA_RIGHT;
            }
            else
            {
                _collision.gameObject.tag = _tagB_LEFT;
            }
        }
    }

    private Vector2[] GetLocalColliderPoints()
    {
        Vector2[] localPoints = new Vector2[4];
        Vector2[] worldPoints = new Vector2[4];

        Bounds bounds = _boxCollider.bounds;
        Vector2 center = bounds.center;
        Vector2 extents = bounds.extents;

        localPoints[0] = transform.InverseTransformPoint(center + new Vector2(extents.x, extents.y));
        localPoints[1] = transform.InverseTransformPoint(center + new Vector2(-extents.x, extents.y));
        localPoints[2] = transform.InverseTransformPoint(center + new Vector2(-extents.x, -extents.y));
        localPoints[3] = transform.InverseTransformPoint(center + new Vector2(extents.x, -extents.y));

        return localPoints;
    }

    private Vector2[] GetLocalContactPoints(Collision2D collision)
    {
        int contactCount = collision.contactCount;
        Vector2[] localContactPoints = new Vector2[contactCount];

        for (int i = 0; i < contactCount; i++)
        {
            localContactPoints[i] = transform.InverseTransformPoint(collision.GetContact(i).point);
        }

        return localContactPoints;
    }

    private bool IsRightSide(Vector2 localPoint, float rotationZ)
    {
        bool isRightSide = false;

        if (Mathf.Approximately(rotationZ, 0f))
        {
            // 0 degrees rotation
            isRightSide = localPoint.x > (_localColliderPoints[0].x + _localColliderPoints[1].x) / 2f;
        }
        else if (Mathf.Approximately(rotationZ, 90f))
        {
            // 90 degrees rotation
            isRightSide = localPoint.y > (_localColliderPoints[0].y + _localColliderPoints[2].y) / 2f;
        }
        else if (Mathf.Approximately(rotationZ, 180f))
        {
            // 180 degrees rotation
            isRightSide = localPoint.x > (_localColliderPoints[0].x + _localColliderPoints[1].x) / 2f;
        }
        else if (Mathf.Approximately(rotationZ, -90f))
        {
            // -90 degrees rotation
            isRightSide = localPoint.y > (_localColliderPoints[0].y + _localColliderPoints[2].y) / 2f;
        }

        return isRightSide;
    }
}