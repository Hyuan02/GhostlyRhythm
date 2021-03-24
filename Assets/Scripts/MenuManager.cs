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
    // Start is called before the first frame update
    void Start()
    {

       Time.timeScale = 1f;
       currentmode = PlayerPrefs.GetInt("AudioMode", 1);
       audioToggles.ForEach(e=>e.isOn = currentmode == 0 ? true : false);
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


}
