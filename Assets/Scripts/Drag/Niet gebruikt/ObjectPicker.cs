using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    // private Transform pickedObject;
    // private bool isObjectPicked = false;
    // private Vector2 offset;

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    //         if (hit.collider != null && hit.collider.CompareTag("Pickable"))
    //         {
    //             pickedObject = hit.collider.transform;
    //             isObjectPicked = true;
    //             offset = pickedObject.position - hit.point;
    //         }
    //     }

    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         if (isObjectPicked)
    //         {
    //             RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    //             if (hit.collider != null && hit.collider.CompareTag("Target"))
    //             {
    //                 pickedObject.position = hit.collider.transform.position;
    //                 pickedObject.SetParent(hit.collider.transform);
    //             }
    //             else
    //             {
    //                 pickedObject.SetParent(null);
    //             }

    //             isObjectPicked = false;
    //         }
    //     }

    //     if (isObjectPicked)
    //     {
    //         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         pickedObject.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, 0);
    //     }
    // }
}