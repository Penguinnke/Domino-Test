using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image sourceImage;
    public Sprite upImage;
    public Sprite downImage;
    public Sprite leftImage;
    public Sprite rightImage;
    public Sprite defaultImage;

    private void Update()
    {
        // Get the input axis for horizontal and vertical movement (arrow keys)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Check if the up arrow key is pressed
        if (verticalInput > 0f)
        {
            // Set the source image sprite to the up image
            sourceImage.sprite = upImage;
        }
        // Check if the down arrow key is pressed
        else if (verticalInput < 0f)
        {
            // Set the source image sprite to the down image
            sourceImage.sprite = downImage;
        }
        // Check if the right arrow key is pressed
        else if (horizontalInput > 0f)
        {
            // Set the source image sprite to the right image
            sourceImage.sprite = rightImage;
        }
        // Check if the left arrow key is pressed
        else if (horizontalInput < 0f)
        {
            // Set the source image sprite to the left image
            sourceImage.sprite = leftImage;
        }
        else
        {
            // Set the source image sprite to the default image
            sourceImage.sprite = defaultImage;
        }
    }
}