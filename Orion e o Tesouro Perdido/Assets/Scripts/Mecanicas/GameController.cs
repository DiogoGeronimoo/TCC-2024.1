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
    public Text scoreText;
    public int totalScore;
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
        Time.timeScale = 0f;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    
    
}