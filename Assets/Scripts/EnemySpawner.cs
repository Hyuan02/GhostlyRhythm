using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyObject;
    private GameObject[] enemies = new GameObject[] {};
    AudioSource audioSource;
    
    private  float[] posY = new float[] { 3f,1.5f, 0, -1.5f, -3f };

    private float enemyZ, enemyX;
    [SerializeField]
    private GameObject movingDolly;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        enemyZ = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource.timeSamples);  
        spawnEnemies();
    }

   

    void spawnEnemies(){
        
        if(audioSource.timeSamples == 709363){
           enemies[0] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+15f, 0, enemyZ), transform.rotation );
           
        }
    }

     void moveEnemies(){
        
        if(audioSource.timeSamples == 709363){
           enemies[0] = Instantiate(enemyObject,this.transform);
          
        }
    }


}


