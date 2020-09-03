using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float highscore;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    public bool CheckHighscore(int score)
    {
        if(score > highscore)
        {
            ChangeHighscore(score);
            return true;
        }
        return false;
    }

    public void ChangeHighscore(int score)
    {
        PlayerPrefs.SetInt("Highscore", score);

        if (scoreText != null)
            scoreText.text = score.ToString();
    }
}
