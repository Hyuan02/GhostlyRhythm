using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioConfigLoader : MonoBehaviour
{


    private void Awake()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetInt("AudioMode", 1) + 1f ;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
