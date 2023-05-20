using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOnDomino : MonoBehaviour
{
    public string _dominoTag = "Domino1";
    public string _dominoTag2 = "Domino2";
    
    private void OnCollisionEnter2D(Collision2D _collision) 
        {
            if (_collision.gameObject.tag == _dominoTag)
            {
                _collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }

            if (_collision.gameObject.tag == _dominoTag2)
            {
                _collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            }
        }
}
