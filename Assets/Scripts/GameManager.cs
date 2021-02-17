using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public static GameManager instance;

    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private GameObject gameOverScreen = null;
    [SerializeField]
    private GameObject player = null;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }


    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
        this.player.SetActive(true);
        ResetScore();
    }

    public void CallGameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void ChangeToMenuScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    void UpdateScore()
    {
        scoreText.text = " " + score;
    }

    public void IncrementScore()
    {
        score += 100;
        UpdateScore();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScore();
    }
}
