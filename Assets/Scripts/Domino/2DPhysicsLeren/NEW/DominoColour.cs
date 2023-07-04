using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoColour : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;

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

    public Color collisionColor; // The color to apply upon collision
    public Color wrongCollisionColor;// The color to apply upon collision with a wrong tag
    public Color exitColor; // The color to apply when the collision ends
    public float delay = 2f; // The delay in seconds before changing the color back
    private SpriteRenderer spriteRenderer;
    private Coroutine colorChangeCoroutine;
    
    private void Start()
    {
        //isCollisionDetectedRight = false;
        colliding = false;

        NotCollidingSound();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTagTRUE)
        {
            Debug.Log("Collision!");
            colliding = true;
            isCollisionDetectedRight = true;
            spriteRenderer.color = collisionColor;

            if (colorChangeCoroutine != null)
            {
                StopCoroutine(colorChangeCoroutine);
            }
            colorChangeCoroutine = StartCoroutine(ChangeColorWithDelay(exitColor, delay));
        }

        if(_collision.gameObject.tag == _dominoTagFALSE1)

        {
            Debug.LogError("WRONG COLLISION");
            colliding = false;
            isCollisionDetectedRight = false;
            spriteRenderer.color = wrongCollisionColor;
        }

        if(_collision.gameObject.tag == _dominoTagFALSE2)
        {
            Debug.LogError("WRONG COLLISION");
            colliding = false;
            isCollisionDetectedRight = false;
            spriteRenderer.color = wrongCollisionColor;

        }

        if(_collision.gameObject.tag == _dominoTagFALSE3)
        {
            Debug.LogError("WRONG COLLISION");
            colliding = false;
            isCollisionDetectedRight = false;
            spriteRenderer.color = wrongCollisionColor;

        }

        
        if(_collision.gameObject.tag == _dominoTagFALSE4)
        {
            Debug.LogError("WRONG COLLISION");
            colliding = false;
            isCollisionDetectedRight = false;
            spriteRenderer.color = wrongCollisionColor;
        }

        if(_collision.gameObject.tag == _dominoTagFALSE5)
        {
            Debug.LogError("WRONG COLLISION");
            colliding = false;
            isCollisionDetectedRight = false;
            spriteRenderer.color = wrongCollisionColor;
        } 

        CollidingSound(); //hier moet ik dus hebben wanneer de colliding goed is dat die de position vastzet
        NotCollidingSound(); //hier meot ik dus ervoor zorgen dat de freezing dan uit is
        
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag == _dominoTagTRUE)
        {
            isCollisionDetectedRight = false;

            if (colorChangeCoroutine != null)
            {
                StopCoroutine(colorChangeCoroutine);
            }

            colorChangeCoroutine = StartCoroutine(ChangeColorWithDelay(exitColor, delay));
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

    private IEnumerator ChangeColorWithDelay(Color targetColor, float delay)
    {
        yield return new WaitForSeconds(delay);

        spriteRenderer.color = targetColor;
    }
}