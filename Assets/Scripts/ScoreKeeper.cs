using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static int score;
    private TextMeshPro scoreText;

    private void Awake()
    {
        score = 0;
        BirdController.onPassPipe += increaseScore;
        scoreText = GetComponent<TextMeshPro>();
        scoreText.color = new Vector4(scoreText.color.r, scoreText.color.g, scoreText.color.b, 0f);

        MenuController.onBeginGame += activate;
    }

    private void OnDisable()
    {
        BirdController.onPassPipe -= increaseScore;
        MenuController.onBeginGame -= activate;
    }

    void increaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void activate()
    {
        scoreText.color = new Vector4(scoreText.color.r, scoreText.color.g, scoreText.color.b, 1f);
    }
}
