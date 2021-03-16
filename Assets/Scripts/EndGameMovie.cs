using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VideoPlayer))]
public class EndGameMovie : MonoBehaviour
{
    VideoPlayer actualPlayer;
    private void Start()
    {
        actualPlayer = GetComponent<VideoPlayer>();
        actualPlayer.loopPointReached += ChangeToInitScene; 
        
    }

    private void ChangeToInitScene(VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

}
