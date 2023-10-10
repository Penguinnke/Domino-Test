using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pot : MonoBehaviour
{
    private int colorIndex = 0; // To keep track of the expected color index
    public bool won = false;
    public string WinScreen;
    public string LooseScreen;

    private int collisionCount = 0; // Counter for collisions loosing

    private string[] expectedColors = { "Purple", "Red", "Yellow", "Blue" };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(expectedColors[colorIndex]))
        {
            colorIndex++;

            if (colorIndex == expectedColors.Length)
            {
                Debug.Log("Won");
                SceneManager.LoadScene(WinScreen);
                won = true;
            }
        }

        if (collision.gameObject)
        {
            collisionCount++; // Increment the collision count
            Debug.Log(collisionCount);
            
            if (collisionCount == 4 && !won) // Check won condition after collisionCount
            {
                Debug.Log("Lost");
                SceneManager.LoadScene(LooseScreen);
            }
        }
    }
}
