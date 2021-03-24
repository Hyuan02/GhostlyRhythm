using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    List<Toggle> audioToggles = null;
    [SerializeField]
    AudioSource mainSource = null;
    int currentmode = 1;

    [SerializeField]
    Text starsText = null;

    [SerializeField]
    private Sprite ActiveStar;
    [SerializeField]
    private Sprite InactiveStar;

    [SerializeField]
    public Image[] stars1;
    [SerializeField]
    public Image[] stars2;

    public int starsTotal = 0;
    public int starsFase1 = 0;
    public int starsFase2 = 0;

    // Start is called before the first frame update
    void Start()
    {

       Time.timeScale = 1f;
       currentmode = PlayerPrefs.GetInt("AudioMode", 1);
       audioToggles.ForEach(e=>e.isOn = currentmode == 0 ? true : false);
       UpdateStarsT();
       UpdateStars1();
       UpdateStars2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void ChangeAudioMode(int toggle)
    {

        PlayerPrefs.SetInt("AudioMode", audioToggles[toggle].isOn ? 0 : 1);
        if(mainSource)
            mainSource.volume = audioToggles[toggle].isOn ? 0 : 1;

        bool currentValue = audioToggles[toggle].isOn;
        audioToggles.ForEach(e =>
        {
            e.isOn = currentValue;
        });
    }
    
    public void ExitApplication()
    {
        Application.Quit();
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayLevelTwo()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
    }

    void UpdateStars1()
    {
    	if(starsFase1 < PlayerPrefs.GetInt("stars1"))
    	{
    		starsFase1 = PlayerPrefs.GetInt("stars1");
    	}

    	if(starsFase1 == 3){
    		stars1[0].sprite = ActiveStar;
    		stars1[1].sprite = ActiveStar;
    		stars1[2].sprite = ActiveStar;
    	} else if(starsFase1 == 2){
    		stars1[0].sprite = ActiveStar;
    		stars1[1].sprite = ActiveStar;
    		stars1[2].sprite = InactiveStar;
    	} else if(starsFase1 == 1){
    		stars1[0].sprite = ActiveStar;
    		stars1[1].sprite = InactiveStar;
    		stars1[2].sprite = InactiveStar;
    	} else {
    		stars1[0].sprite = InactiveStar;
    		stars1[1].sprite = InactiveStar;
    		stars1[2].sprite = InactiveStar;
    	}
    }

    void UpdateStars2()
    {
    	if(starsFase2 < PlayerPrefs.GetInt("stars2"))
    	{
    		starsFase2 = PlayerPrefs.GetInt("stars2");
    	}

    	if(starsFase2 == 3){
    		stars2[0].sprite = ActiveStar;
    		stars2[1].sprite = ActiveStar;
    		stars2[2].sprite = ActiveStar;
    	} else if(starsFase2 == 2){
    		stars2[0].sprite = ActiveStar;
    		stars2[1].sprite = ActiveStar;
    		stars2[2].sprite = InactiveStar;
    	} else if(starsFase2 == 1){
    		stars2[0].sprite = ActiveStar;
    		stars2[1].sprite = InactiveStar;
    		stars2[2].sprite = InactiveStar;
    	} else {
    		stars2[0].sprite = InactiveStar;
    		stars2[1].sprite = InactiveStar;
    		stars2[2].sprite = InactiveStar;
    	}
    }

    void UpdateStarsT()
    {
    	starsText.text = "0" + (starsFase1 + starsFase2);
    }


}
