using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Renderer spriteRenderer;
    public AudioSource audioSource; 

    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            Debug.Log("Collision with pot");
            
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }
            
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }
        }
    }
}
