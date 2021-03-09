using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VideoPlayer))]
public class EndGameMovie : MonoBehaviour
{
    VideoPlayer actualPlayer;
    bool activated = false;
    private void Start()
    {
        actualPlayer = GetComponent<VideoPlayer>();
        
    }

    private void Update()
    {
        if(actualPlayer.time >= actualPlayer.clip.length && !activated)
        {
            activated = true;
            ChangeToInitScene();
        }
    }

    private void ChangeToInitScene()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

}
