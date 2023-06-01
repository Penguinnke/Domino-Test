using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollision : MonoBehaviour
{
    //public DraggingDomino Dragging;
    //public DraggingDomino Placed;

    private Vector2 _offset, _orginalPosition;

    public string _dominoTagTRUE = "Domino1"; //the domino tag it needs to collide with
    public string _dominoTagFALSE1 = "Domino1"; //the domino tag it needs to collide with
    public string _dominoTagFALSE2 = "Domino2"; //the domino tag it needs to collide with
    public string _dominoTagFALSE3 = "Domino3"; //the domino tag it needs to collide with
    public string _dominoTagFALSE4 = "Domino4"; //the domino tag it needs to collide with
    public string _dominoTagFALSE5 = "Domino5"; //the domino tag it needs to collide with

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTagTRUE)
        {
            Debug.Log("Collision!");
            // Dragging._dragging = false;
            // Placed._placed = true
        }

        if(_collision.gameObject.tag == _dominoTagFALSE1)
        {
            Debug.Log("Not Collision!");
        }

        if(_collision.gameObject.tag == _dominoTagFALSE2)
        {
            Debug.Log("Not Collision!");
        }

        if(_collision.gameObject.tag == _dominoTagFALSE3)
        {
            Debug.Log("Not Collision!");
        }

        
        if(_collision.gameObject.tag == _dominoTagFALSE4)
        {
            Debug.Log("Not Collision!");
        }

        if(_collision.gameObject.tag == _dominoTagFALSE5)
        {
            Debug.Log("Not Collision!");
        }       
    }
}
