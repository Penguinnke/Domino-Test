using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoColourChange : MonoBehaviour
{   //Hoe ik deze bug denk ik kan fixen is door het of in het draggingcolliding script te doen of 
    //OF door de gameobject public te maken en daar mee verder te gaan?
    //OF om dit script op de domino deel te zetten?


    public string targetTag; // The tag of the object that triggers the color change
    public Color collisionColor; // The color to apply upon collision
    public Color wrongCollisionColor;// The color to apply upon collision with a wrong tag
    public Color exitColor; // The color to apply when the collision ends
    public float delay = 2f; // The delay in seconds before changing the color back

    private SpriteRenderer spriteRenderer;
    private Coroutine colorChangeCoroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            spriteRenderer.color = collisionColor;
        }

        if (!collision.gameObject.CompareTag(targetTag))
        {
            spriteRenderer.color = wrongCollisionColor;
            Debug.LogError("WRONG COLLISION"); //hij denk altijd dat de collision verkeerd is terwijl dat niet zo is!
            if (colorChangeCoroutine != null)
            {
                StopCoroutine(colorChangeCoroutine);
            }
            colorChangeCoroutine = StartCoroutine(ChangeColorWithDelay(exitColor, delay));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            if (colorChangeCoroutine != null)
            {
                StopCoroutine(colorChangeCoroutine);
            }

            colorChangeCoroutine = StartCoroutine(ChangeColorWithDelay(exitColor, delay));
        }
    }

    private IEnumerator ChangeColorWithDelay(Color targetColor, float delay)
    {
        yield return new WaitForSeconds(delay);

        spriteRenderer.color = targetColor;
    }
}
