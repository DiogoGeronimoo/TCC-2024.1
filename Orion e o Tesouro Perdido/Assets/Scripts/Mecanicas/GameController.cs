using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public Text healthText;
    public int score;
    public int score1;
    public Text scoreText1;
    public Text scoreText;
    public int totalScore;
    public int totalScore1;
    public static GameControler instance;
    public GameObject pauseObj;
    public GameObject gameOverObj;
    public GameObject creditosObj;
    private bool isPaused;
    
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        totalScore = PlayerPrefs.GetInt("score");
        totalScore1 = PlayerPrefs.GetInt("score1");

    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();

    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score + totalScore);
    }

    public void UpdateScore1(int value)
    {
        score1 += value;
        scoreText1.text = score1.ToString();
        PlayerPrefs.SetInt("score1", score1 + totalScore1);
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x" + value.ToString();
    }
    

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2);

    }
    public void Quit()
    {
        SceneManager.LoadScene(0);

    }
    
    public void Creditos()
    {
        creditosObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReiniciarFase()
    { 
        gameOverObj.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    
    
}