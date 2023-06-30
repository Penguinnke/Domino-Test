using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollision : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;

    private Vector2 _offset, _orginalPosition;

    public string _dominoTagTRUE = "Domino1"; //the domino tag it needs to collide with
    public string _dominoTagFALSE1 = "Domino1"; //the domino tag it needs to collide with
    public string _dominoTagFALSE2 = "Domino2"; //the domino tag it needs to collide with
    public string _dominoTagFALSE3 = "Domino3"; //the domino tag it needs to collide with
    public string _dominoTagFALSE4 = "Domino4"; //the domino tag it needs to collide with
    public string _dominoTagFALSE5 = "Domino5"; //the domino tag it needs to collide with

    private void Start()
    {
        isCollisionDetectedRight = false;
    }
    
    
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTagTRUE)
        {
            Debug.Log("Collision!");
            colliding = true;
            isCollisionDetectedRight = true;
        }

        if(_collision.gameObject.tag == _dominoTagFALSE1)

        {
            Debug.Log("Not Collision!");
            colliding = false;
            isCollisionDetectedRight = false;
        }

        if(_collision.gameObject.tag == _dominoTagFALSE2)
        {
            Debug.Log("Not Collision!");
            colliding = false;
            isCollisionDetectedRight = false;

        }

        if(_collision.gameObject.tag == _dominoTagFALSE3)
        {
            Debug.Log("Not Collision!");
            colliding = false;
            isCollisionDetectedRight = false;

        }

        
        if(_collision.gameObject.tag == _dominoTagFALSE4)
        {
            Debug.Log("Not Collision!");
            colliding = false;
            isCollisionDetectedRight = false;
        }

        if(_collision.gameObject.tag == _dominoTagFALSE5)
        {
            Debug.Log("Not Collision!");
            colliding = false;
            isCollisionDetectedRight = false;
        }       
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTagTRUE)
        {
            isCollisionDetectedRight = false;
        }
    }

    private void Update()
    {
        if (!isCollisionDetectedRight)
        {
            //unfreeze the component
        } else {
            //there is collision detected and I need to freeze the component
        }
    }

}
