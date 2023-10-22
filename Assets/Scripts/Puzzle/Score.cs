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
    public AudioSource audioSource;
    public AudioClip collisionSound;

    private void Update()
    {
        scoreText.text = "Score: " + score + "/4";

        if (score == 4)
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

    private void PlayCollisionSound()
    {
        if (audioSource != null && collisionSound != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Vaas1"))
        {
            score++;
            Vaas1.SetActive(false);
            PlayCollisionSound();
        }

        if (collision.gameObject.CompareTag("Vaas2"))
        {
            score++;
            Vaas2.SetActive(false);
            PlayCollisionSound();
        }

        if (collision.gameObject.CompareTag("Vaas3"))
        {
            score++;
            Vaas3.SetActive(false);
            PlayCollisionSound();
        }

        if (collision.gameObject.CompareTag("Vaas4"))
        {
            score++;
            Vaas4.SetActive(false);
            PlayCollisionSound();
        }
    }
}
