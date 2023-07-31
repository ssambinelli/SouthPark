using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float initialGameSpeed;
    public float gameSpeedIncrease;
    public float gameSpeed {get; private set;}
    private Player player;
    private Obstacle obstacle;


    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Button retryButton;

    //USING FLOAT BECAUSE OF TIME (COULD BE MS)
    public float score;
    // MAKE SURE TO CREATE AN INSTANCE AND IF HAS MORE THAN ONE DESTROY IMMEDIATLY
    private void Awake() 
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }else 
        {
            Instance = this;
        }
    }
    private void OnDestroy() {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    private void Start() {
        player = FindObjectOfType<Player>();
        obstacle = FindObjectOfType<Obstacle>();
        NewGame();
    }

    public void NewGame()
    {
        ObstacleMovement[] obstacles = FindObjectsOfType<ObstacleMovement>();
        foreach (var item in obstacles)
        {
            Destroy(item.gameObject);   
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        obstacle.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHighScore();
    }

    private void Update() {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;
        player.gameObject.SetActive(false);
        obstacle.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        float highscore = PlayerPrefs.GetFloat("highscore", 0);

        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
        highScoreText.text = ("HI ") + Mathf.FloorToInt(highscore).ToString("D5");
    }
}
