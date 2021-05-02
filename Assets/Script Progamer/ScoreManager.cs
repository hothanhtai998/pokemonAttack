using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int scores;
    public int bestScore;
    //public int bestScore;
    public Text scoreText;
    public Text bestScoreText;
    //Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
            bestScoreText.text = bestScore.ToString();
        }
    }


    public void AddScore(int amount)
    {
        scores += amount;
        UpdateBestScore();
        scoreText.text = scores.ToString();
    }


    public void UpdateBestScore()
    {
        if (scores > bestScore)
        {
            bestScore = scores;
            bestScoreText.text = bestScore.ToString();
            PlayerPrefs.SetInt("BestScore", scores);
        }
    }

    public void ResetScore()
    {
        scores = 0;
    }

    public void ClearBestScore()
    {
        PlayerPrefs.DeleteKey("BestScore");
        bestScore = 0;
        bestScoreText.text = bestScore.ToString();
    }
}
