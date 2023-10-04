using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoColourZero : MonoBehaviour
{
    public bool colliding;
    public bool isCollisionDetectedRight;

    // Audio source names
    public string collidingSoundName = "CollidingSound";
    public string notCollidingSoundName = "NotCollidingSound";

    private Vector2 _offset, _orginalPosition;

    public Color collisionColor;
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
        Debug.Log("Collision!");
        colliding = true;
        isCollisionDetectedRight = true;
        spriteRenderer.color = collisionColor;

        if (colorChangeCoroutine != null)
        {
            StopCoroutine(colorChangeCoroutine);
        }
        colorChangeCoroutine = StartCoroutine(ChangeColorWithDelay(exitColor, delay));

        CollidingSound();
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
}