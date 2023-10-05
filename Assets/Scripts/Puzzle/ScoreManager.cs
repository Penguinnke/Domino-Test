using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI  scoreText; // Reference to a UI Text element to display the score
    private int score = 0;

    // Singleton pattern to ensure there's only one ScoreManager instance
    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
    
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
            Debug.Log("Score updated: " + scoreText.text);
        }
    }
}