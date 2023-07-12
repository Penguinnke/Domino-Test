using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2D : MonoBehaviour
{
    public Transform lightSource;
    public Color lightColor;
    public float lightRadius;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Set the color of the light
        spriteRenderer.color = lightColor;

        // Set the scale of the light based on the radius
        transform.localScale = new Vector3(lightRadius, lightRadius, 1f);

        // Position the light source
        transform.position = lightSource.position;
    }
}