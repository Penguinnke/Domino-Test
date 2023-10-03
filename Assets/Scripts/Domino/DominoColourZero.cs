using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoColourZero : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;

    //Audio
    public AudioSource audiosourcecolliding;
    public AudioSource audiosourcenotcolliding;


    private Vector2 _offset, _orginalPosition;

    public Color collisionColor; // The color to apply upon collision
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
        audiosourcecolliding = GetComponent<AudioSource>();
        audiosourcenotcolliding = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter2D(Collision2D _collision)
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

        CollidingSound(); //hier moet ik dus hebben wanneer de colliding goed is dat die de position vastzet
        
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
            isCollisionDetectedRight = false;

            if (colorChangeCoroutine != null)
            {
                StopCoroutine(colorChangeCoroutine);
            }
            colorChangeCoroutine = StartCoroutine(ChangeColorWithDelay(exitColor, delay));
    }


   private void CollidingSound()
    {
        if (isCollisionDetectedRight == true)
        {
            AudioSource audioSource = audiosourcecolliding.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("Played");
            }
        }
    }
    private IEnumerator ChangeColorWithDelay(Color targetColor, float delay)
    {
        yield return new WaitForSeconds(delay);

        spriteRenderer.color = targetColor;
    }

    private void NotCollidingSound()
   {
        if (isCollisionDetectedRight == false)
        {
            AudioSource audioSource = audiosourcenotcolliding.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}