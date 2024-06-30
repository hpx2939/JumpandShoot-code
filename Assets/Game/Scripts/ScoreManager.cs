using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int currentScore = 0;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI best;
 
    void Start()
    {
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        currentScoreText.text = currentScore.ToString();
    }


    public void AddScore()
    {
        currentScore++;
        currentScoreText.text = currentScore.ToString();

        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            bestScoreText.text = currentScore.ToString();
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
    }
   public void ChangeColorToWhite()
    {
        bestScoreText.color = Color.yellow;
        currentScoreText.color = Color.white;
        best.color = Color.yellow;
    }

}
