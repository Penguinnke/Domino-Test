using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public int score = 10;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro object in the Inspector
    public string LooseScreen;

    public void Start()
    {
        UpdateScoreDisplay();
    }
    // Method to update the score display using TextMeshPro
    public void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            // Update the TextMeshPro text component with the current score
            scoreText.text = "Score:" + score.ToString() + "/10";
        }
    }

    public void DecreaseScore(int amount)
    {
        score -= amount;
        UpdateScoreDisplay();
    }

    void Update()
    {
        if (score == 0)
        {
            SceneManager.LoadScene(LooseScreen);
        }
    }
}