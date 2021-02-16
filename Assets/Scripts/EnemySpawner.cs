using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyObject;
    private GameObject[] enemies = new GameObject[10];

    private bool[] enemySpawn = new bool[10]; 
    private bool[] enemyMove = new bool[10]; 
    AudioSource audioSource;
    
    private  float[] posY = new float[] { 3f,1.5f, 0, -1.5f, -3f };

    private float enemyZ, enemyX;
    private int enemyVelocity = -30;

    private float enemyOffsetX = 16.5f;
    [SerializeField]
    private GameObject movingDolly;
    

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        enemyZ = 2f;
        for(int i = 0; i < 10;i++){
            enemySpawn[i] = false;
            enemyMove[i] = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource.timeSamples);  
        spawnEnemies();
        moveTriggerEnemies();
        moveEnemies();
    }

   

    void spawnEnemies(){
        
        if(audioSource.timeSamples == 700895 && enemySpawn[0] == false){
           var enemyY = TrailsManager.instance.OccupiedTrail.trailObject.transform.position.y; 
           //Debug.Log(enemyY);
           enemies[0] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[0] = true;
        }
    }

     void moveTriggerEnemies(){
        
        if(audioSource.timeSamples == 709363 && enemySpawn[0] == true){
           //Debug.Log("BOP");
           //Debug.Log(enemies[0]);
           enemyMove[0] = true;
        }

        
    }

    void moveEnemies(){
        if(enemyMove[0] == true ){
            if(enemies[0] != null){
                enemies[0].transform.Translate(new Vector3(enemyVelocity,0,0) * Time.deltaTime);
            }
            else{
                //Debug.Log("Dead");
            } 
        }
    }


}


