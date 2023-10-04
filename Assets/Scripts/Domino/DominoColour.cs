using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoColour : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;

    // Audio source names
    public string collidingSoundName = "CollidingSound";
    public string notCollidingSoundName = "NotCollidingSound";

    private Vector2 _offset, _orginalPosition;

    public string _dominoTagTRUE = "Domino1"; //the domino tag it needs to collide with
    public string _dominoTagTrueZero = "Domino0"; //Number 0 is always good

    public Color collisionColor;
    public Color wrongCollisionColor;
    public Color exitColor;
    public float delay = 2f;
    private SpriteRenderer spriteRenderer;
    private Coroutine colorChangeCoroutine;

    private void Start()
    {
        colliding = false;
        NotCollidingSound();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == _dominoTagTRUE || _collision.gameObject.tag == _dominoTagTrueZero)
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
        else
        {
            Debug.LogError("WRONG COLLISION");
            spriteRenderer.color = wrongCollisionColor;

            if (colorChangeCoroutine != null)
            {
                isCollisionDetectedRight = false;
                StopCoroutine(colorChangeCoroutine);
            }
            colorChangeCoroutine = StartCoroutine(ChangeColorWithDelay(exitColor, delay));
        }

        CollidingSound();
        NotCollidingSound();
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        if (_collision.gameObject.tag == _dominoTagTRUE || _collision.gameObject.tag == _dominoTagTrueZero)
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
            AudioSource audioSource = GameObject.Find(notCollidingSoundName).GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
                Debug.Log("NotCollidingSound");
            }
        }
    }

    private void CollidingSound()
    {
        if (isCollisionDetectedRight == true)
        {
            AudioSource audioSource = GameObject.Find(collidingSoundName).GetComponent<AudioSource>();
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
}