using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    // private bool isPickedUp = false;
    // private GameObject pickedObject;
    // private Vector2 offset;
    // private GameObject[] pickedObjects;
    // private Vector2[] offsets;

    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

    //         if (hit.collider != null && hit.collider.CompareTag("Pickupable"))
    //         {
    //             if (!isPickedUp)
    //             {
    //                 isPickedUp = true;
    //                 pickedObjects = new GameObject[] { hit.collider.gameObject };
    //                 offsets = new Vector2[] { pickedObjects[0].transform.position - mousePosition };
    //             }
    //             else
    //             {
    //                 GameObject[] newPickedObjects = new GameObject[pickedObjects.Length + 1];
    //                 Vector2[] newOffsets = new Vector2[offsets.Length + 1];

    //                 for (int i = 0; i < pickedObjects.Length; i++)
    //                 {
    //                     newPickedObjects[i] = pickedObjects[i];
    //                     newOffsets[i] = offsets[i];
    //                 }

    //                 newPickedObjects[pickedObjects.Length] = hit.collider.gameObject;
    //                 newOffsets[offsets.Length] = newPickedObjects[pickedObjects.Length].transform.position - mousePosition;

    //                 pickedObjects = newPickedObjects;
    //                 offsets = newOffsets;
    //             }
    //         }
    //     }

    //     if (isPickedUp && Input.GetMouseButton(0))
    //     {
    //         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //         for (int i = 0; i < pickedObjects.Length; i++)
    //         {
    //             pickedObjects[i].transform.position = mousePosition + offsets[i];
    //         }
    //     }

    //     if (isPickedUp && Input.GetMouseButtonUp(0))
    //     {
    //         isPickedUp = false;
    //     }
    // }
}


