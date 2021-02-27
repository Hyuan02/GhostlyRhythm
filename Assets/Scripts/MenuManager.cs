using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Toggle audioToggle = null;
    [SerializeField]
    AudioSource mainSource = null;
    int currentmode = 1;
    // Start is called before the first frame update
    void Start()
    {

       Time.timeScale = 1f;
       currentmode = PlayerPrefs.GetInt("AudioMode", 1);
       audioToggle.isOn = currentmode == 0 ? true : false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void ChangeAudioMode()
    {
        PlayerPrefs.SetInt("AudioMode", audioToggle.isOn ? 0 : 1);
        if(mainSource)
            mainSource.volume = audioToggle.isOn ? 0 : 1;
    }
    
    public void ExitApplication()
    {
        Application.Quit();
    }


}
