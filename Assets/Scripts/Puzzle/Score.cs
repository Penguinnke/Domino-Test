using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public GameObject Vaas1;
    public GameObject Vaas2;
    public GameObject Vaas3;
    public GameObject Vaas4;

    public string Score4Scene;

    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + score +"/4";

        if(score == 4)
        {
            Debug.Log("Finished");
            Invoke("ChangeSceneAfterDelay", 2.0f);
            scoreText.text = "Finished! Good Job!";
        }
    }

     private void ChangeSceneAfterDelay()
    {
        SceneManager.LoadScene(Score4Scene);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Vaas1"))
        {
            // Increase the score by one
            score++;

            // Turn off the object that this script is attached to
            Vaas1.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Vaas2"))
        {
            // Increase the score by one
            score++;

            // Turn off the object that this script is attached to
            Vaas2.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Vaas3"))
        {
            // Increase the score by one
            score++;

            // Turn off the object that this script is attached to
            Vaas3.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Vaas4"))
        {
            // Increase the score by one
            score++;

            // Turn off the object that this script is attached to
            Vaas4.SetActive(false);
        }
    }
    
}