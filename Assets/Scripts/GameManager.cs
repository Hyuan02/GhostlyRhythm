using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

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
    [SerializeField]
    private AudioSource mainMusic = null;
    [Range(0f, 40f)]
    [SerializeField]
    private float timeOfMusicToStart = 0.0f;
    [SerializeField]
    private EnemySpawner spawner = null;

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
        
        if (mainMusic)
        {
            mainMusic.Stop();
            mainMusic.time = timeOfMusicToStart;
            mainMusic.Play();

        }
        if (spawner)
        {
            spawner.ResetVectors();
            ClearEnemies();
        }

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
        if(scoreText)
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

    void ClearEnemies()
    {
        var enemies = this.spawner.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
        for (int i = 0; i < enemies.Count; i++)
        {
            DestroyImmediate(enemies[i]);
        }
    }
}
