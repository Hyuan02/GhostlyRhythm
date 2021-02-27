using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public static GameManager instance;

    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text gameOverScoreText = null;
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
        PlayerPrefs.SetString("FadeSound", "false");
    }


public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }


    

    public void RestartGame()
    {
        
        mainMusic.volume = 1;
        if (mainMusic)
        {
            mainMusic.Stop();
            mainMusic.time = timeOfMusicToStart;
            
           // PlayerPrefs.SetString("FadeSound", "false");
            mainMusic.Play();

        }
        if (spawner)
        {  
            spawner.ResetVectors();
            ClearEnemies();
            
        }

        gameOverScreen.SetActive(false);
        
        Time.timeScale = 1;
        this.player.GetComponent<MovingManager>().StartPlayer();
        this.player.SetActive(true);
        ResetScore();
    }

    public void CallGameOver()
    {   
        
        Time.timeScale = 0;
        UpdateGameOverScore();
        gameOverScreen.SetActive(true);
        AnalyticsResult analyticsResult = Analytics.CustomEvent(
            "Death", new Dictionary<string, object>{
            {"Death level", score}

        });

        //Debug.Log(analyticsResult);
      //  StartCoroutine(StartFade(mainMusic, 3f, 0.3f));
       
        mainMusic.volume = 0.2f;
       // PlayerPrefs.SetString("FadeSound", "true");
        
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

    void UpdateGameOverScore()
    {
        if (gameOverScoreText)
            gameOverScoreText.text = " " + score;
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
