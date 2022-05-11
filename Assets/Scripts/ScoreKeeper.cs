using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject bird;

    private int score;
    private TextMeshPro scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        bird.GetComponent<BirdController>().onPassPipe += increaseScore;
        scoreText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void increaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}