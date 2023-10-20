using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private float score;
    private string highScoreKey = "high_score";

    private void Awake()
    {
        Instance = this;

        ResetScore();
        InitHighScore();
    }

    /// <summary>
    /// Reset current score to zero.
    /// </summary>
    public void ResetScore()
    {
        score = 0;
    }

    /// <summary>
    /// Add value to current score.
    /// </summary>
    public void AddScore(float value)
    {
        score += value;
        if (score < 0) score = 0;
    }

    /// <summary>
    /// Get current score value.
    /// </summary>
    public float GetScore()
    {
        return score;
    }

    /// <summary>
    /// Checks if current score should replace the previous high score.
    /// </summary>
    public void SetHighScore()
    {
        if (score <= GetHighScore()) return;

        PlayerPrefs.SetFloat(highScoreKey, score);
    }

    /// <summary>
    /// Get current high score.
    /// </summary>
    public float GetHighScore()
    {
        return PlayerPrefs.GetFloat(highScoreKey);
    }

    private void InitHighScore()
    {
        if (PlayerPrefs.HasKey(highScoreKey)) return;

        PlayerPrefs.SetFloat(highScoreKey, score);
    }
}
