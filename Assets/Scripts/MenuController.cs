using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MenuController : MonoBehaviour
{
    public static event Action onBeginGame;
    public static event Action onEndGame;

    public GameObject menu;
    public GameObject starterTextObject;
    private TextMeshProUGUI starterText;
    public GameObject enderTextObject;
    private TextMeshProUGUI enderText;

    public static bool playing;
    public static bool began;
    public float fadeSpeed;

    private void Awake()
    {
        menu.SetActive(false);

        starterText = starterTextObject.GetComponent<TextMeshProUGUI>();
        enderText = enderTextObject.GetComponent<TextMeshProUGUI>();
        enderText.color = new Vector4(enderText.color.r, enderText.color.g, enderText.color.b, 0f);

        playing = true;
        began = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (playing)
            {
                pause();
            } else
            {
                resume();
            }
        }
        else if (!began && Input.GetKeyDown(KeyCode.Space))
        {
            began = true;
            starterTextObject.SetActive(false);
            onBeginGame();
        }
        else if (BirdController.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            onEndGame();
        }
    }

    private void FixedUpdate()
    {
        if (!began)
        {
            float newAlpha = (1 + Mathf.Cos(fadeSpeed * Time.fixedTime)) / 2;
            starterText.color = new Vector4(starterText.color.r, starterText.color.g, starterText.color.b, newAlpha);
        }
        else if (BirdController.gameOver)
        {
            float newAlpha = (1 + Mathf.Sin(fadeSpeed * Time.fixedTime)) / 2;
            enderText.color = new Vector4(enderText.color.r, enderText.color.g, enderText.color.b, newAlpha);
        }
    }

    void pause()
    {
        menu.SetActive(true);
        starterTextObject.SetActive(false);
        enderTextObject.SetActive(false);
        Time.timeScale = 0f;
        playing = false;
    }

    public void resume()
    {
        menu.SetActive(false);
        if (!began)
        {
            starterTextObject.SetActive(true);
        }
        enderTextObject.SetActive(true);
        Time.timeScale = 1f;
        playing = true;
    }

    public void quit()
    {
        Application.Quit();
    }
}
