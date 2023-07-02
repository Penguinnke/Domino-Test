using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollision : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;

    public Rigidbody2D rb2d; //Rigidbody from the entire Domino

    //Audio
    public AudioSource audiosourcecolliding;
    public AudioSource audiosourcenotcolliding;


    private Vector2 _offset, _orginalPosition;

    public string _dominoTagTRUE = "Domino1"; //the domino tag it needs to collide with
    public string _dominoTagFALSE1 = "Domino1"; //the domino tag it needs to collide with
    public string _dominoTagFALSE2 = "Domino2"; //the domino tag it needs to collide with
    public string _dominoTagFALSE3 = "Domino3"; //the domino tag it needs to collide with
    public string _dominoTagFALSE4 = "Domino4"; //the domino tag it needs to collide with
    public string _dominoTagFALSE5 = "Domino5"; //the domino tag it needs to collide with

    private void Start()
    {
        //isCollisionDetectedRight = false;
        colliding = false;

        NotCollidingSound();
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

        CollidingSound(); //hier moet ik dus hebben wanneer de colliding goed is dat die de position vastzet
        NotCollidingSound(); //hier meot ik dus ervoor zorgen dat de freezing dan uit is
        
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTagTRUE)
        {
            isCollisionDetectedRight = false;
        }
    }


    private void NotCollidingSound()
    {
        if (isCollisionDetectedRight == false)
        {
            audiosourcenotcolliding.Play();
        }
    }

    private void CollidingSound()
    {
        if (isCollisionDetectedRight == true)
        {
            audiosourcecolliding.Play();
            Debug.Log("Played");
        }
    }
    
    private void FixedUpdate()
    {
        if (isCollisionDetectedRight == true)
        {
        //      rb2d.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
        
        // if (isCollisionDetectedRight == false)
        // {
        //     rb2d.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        // }

        
        // Find all GameObjects with the specified tag
        // GameObject[] targets = GameObject.FindGameObjectsWithTag(_dominoTagTRUE);

        // if (targets.Length < 2)
        // {
        //      //Debug.LogError("Not enough objects with the tag " + _dominoTagTRUE + " in the scene.");
        //      //return;
        // }

        // Loop through the objects and calculate the distance between them
        // for (int i = 0; i < targets.Length - 1; i++)
        // {
        //     for (int j = i + 1; j < targets.Length; j++)
        //     {
        //         // Calculate the distance between the current pair of objects
        //         float distance = Vector2.Distance(targets[i].transform.position, targets[j].transform.position);

        //         Debug.Log("Distance between " + targets[i].name + " and " + targets[j].name + ": " + distance);
        //     }
        // }
    }

}

