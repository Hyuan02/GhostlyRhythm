using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class EndGameWatcher : MonoBehaviour
{
    [SerializeField]
    private AudioSource source = null;

    [SerializeField]
    private UnityEvent eventOnEnd = null;

    bool activated = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(source.time >= source.clip.length && !activated)
        {
            eventOnEnd.Invoke();
            activated = true;
        }
    }


}
