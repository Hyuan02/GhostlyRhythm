using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public GameObject enemyObject;
    public float[] spectrum = new float[1024];
    public float spawnThreshold = 0.5f;
    public int frequency = 0;
    public float actualFrequency = 0;
    float[] Ypos = new float[]{3f,0, -3F};
    
    float enemyX;
    float enemyY;
    float enemyZ = 2f;
   

    void Update()
    {
        
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

         actualFrequency = spectrum[frequency]; 
            if(spectrum[frequency] > spawnThreshold){
                
                enemyY = Ypos[Random.Range(0,3)];
                Instantiate(enemyObject,new Vector3(transform.position.x+14,enemyY,enemyZ), transform.rotation);
            }
            /*float targetFrequency = 234f;
            float hertzPerBin = (float)AudioSettings.outputSampleRate / 2f / 1024;
            int targetIndex = (int)(targetFrequency / hertzPerBin);

            string outString = "";
            for (int i = targetIndex - 3; i <= targetIndex + 3; i++) {
                outString += string.Format("| Bin {0} : {1}Hz : {2} |   ", i, i * hertzPerBin, spectrum[i]);
            }

            Debug.Log (outString);*/
            
           
                

    }
}



