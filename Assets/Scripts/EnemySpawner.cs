using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyObject;
    public int enemiesNumber = 50; // ATENÇÃO PARA ESSE NUMERO
    private GameObject[] enemies = new GameObject[50];

    private bool[] enemySpawn = new bool[50]; 
    private bool[] enemyMove = new bool[50]; 

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
        for(int i = 0; i < enemiesNumber;i++){
            enemySpawn[i] = false;
            enemyMove[i] = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(audioSource.timeSamples);  
        spawnEnemies();
        moveTriggerEnemies();
        moveEnemies();
    }

   

    void spawnEnemies(){
        var enemyY = TrailsManager.instance.OccupiedTrail.trailObject.transform.position.y;

        //Debug.Log(enemyY);
        //var enemyY = posY[Random.Range(0,5)];
        if(audioSource.timeSamples == 617164 && enemySpawn[0] == false){   //aprox. 14 segundos/617400 
           enemies[0] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[0] = true;
        }
        if(audioSource.timeSamples == 639743 && enemySpawn[1] == false){   //aprox. 14.5 segundos/651450 
           enemies[1] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[1] = true;
        }
        if(audioSource.timeSamples == 651974 && enemySpawn[2] == false){   //aprox. 15.0 segundos/661500 
           enemies[2] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[2] = true;
        }
        if(audioSource.timeSamples == 683961 && enemySpawn[3] == false){   //aprox. 15.5 segundos/683550 
           enemies[3] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[3] = true;
        }
        if(audioSource.timeSamples == 705599 && enemySpawn[4] == false){   //aprox. 16 segundos/705600
           enemies[4] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[4] = true;
        }
        if(audioSource.timeSamples == 727238 && enemySpawn[5] == false){   //aprox. 16.5 segundos/727650
           enemies[5] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[5] = true;
        }
        if(audioSource.timeSamples == 749817 && enemySpawn[6] == false){   //aprox. 17 segundos/749700
           enemies[6] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[6] = true;
        }
        if(audioSource.timeSamples == 771455 && enemySpawn[7] == false){   //aprox. 17.5 segundos/771750
           enemies[7] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[7] = true;
        }
        if(audioSource.timeSamples == 794035 && enemySpawn[8] == false){   //aprox. 18 segundos/793800
           enemies[8] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[8] = true;
        }
        if(audioSource.timeSamples == 815673 && enemySpawn[9] == false){   //aprox. 18.5 segundos/815850
           enemies[9] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[9] = true;
        }
         if(audioSource.timeSamples == 838252 && enemySpawn[10] == false){   //aprox. 19 segundos/837900
           enemies[10] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[10] = true;
        }



        
      
    }
    /*
    3 aprox. 17.555 segundos/771750
    4 aprox. 18.055 segundos/796260
    5 aprox. 18.555 segundos/818310
    6 aprox. 19.055 segundos/840360
    7 aprox. 19.5   segundos/859950
    8 aprox. 20.057 segundos/884546
    9 aprox. 20.527 segundos/905280
    10 aprox. 21.027 segundos/927330
    11 aprox. 21.555 segundos/950610
    12 aprox. 22.055 segundos/972660
    13 aprox. 22.5 segundos/992250
    14 aprox. 23.055 segundos/1016760
    15 aprox. 23.5 segundos/1036350
    16 aprox. 24.055 segundos/1060860
    17 aprox. 24.555 segundos/1082910
    18 aprox. 25.083 segundos/1106189
    19 aprox. 25.555 segundos/1127010
    20 aprox. 26.055 segundos/1149060
    21 aprox. 26.555 segundos/1171110
    22 aprox. 27.055 segundos/1193160
    23 aprox. 27.555 segundos/1215210
    24 aprox. 28.055 segundos/1237260
    25 aprox. 28.555 segundos/1259310
    26 aprox. 29.055 segundos/1281360
    27 aprox. 29.527 segundos/1302180
    28 aprox. 30.027 segundos/1324230
    29 aprox. 30.555 segundos/1347510
    30 aprox. 31.055 segundos/1369560
    31 aprox. 31.555 segundos/1413660
    32 aprox. 32.583 segundos/1436939

    */
     void moveTriggerEnemies(){
        if(audioSource.timeSamples == 709363 && enemySpawn[0] == true){ //aprox. 16.083 segundos/709283
          enemyMove[0] = true;
        }
         if(audioSource.timeSamples == 727238 && enemySpawn[1] == true){ //aprox. 16.5 segundos/727650
          enemyMove[1] = true;
        }
          if(audioSource.timeSamples == 752639 && enemySpawn[2] == true){ //aprox. 17.055 segundos/752160
          enemyMove[2] = true;
        }
         if(audioSource.timeSamples == 771455 && enemySpawn[3] == true){ //aprox. 17.5 segundos/771750
          enemyMove[3] = true;
        }
        if(audioSource.timeSamples == 796857 && enemySpawn[4] == true){ //aprox. 18.055 segundos/796260
          enemyMove[4] = true;
        }
        if(audioSource.timeSamples == 818495 && enemySpawn[5] == true){ //aprox. 18.555 segundos/818310
          enemyMove[5] = true;
        }
        if(audioSource.timeSamples == 840134 && enemySpawn[6] == true){ //aprox. 19.055 segundos/840360
          enemyMove[6] = true;
        }
        if(audioSource.timeSamples == 859891 && enemySpawn[7] == true){ //aprox. 19.5   segundos/859950
          enemyMove[7] = true;
        }
        if(audioSource.timeSamples == 884351 && enemySpawn[8] == true){ //aprox. 20.057 segundos/884546
          enemyMove[8] = true;
        }
        if(audioSource.timeSamples == 905990 && enemySpawn[9] == true){ //aprox. 20.527 segundos/905280
          enemyMove[9] = true;
        }
        if(audioSource.timeSamples == 927628 && enemySpawn[10] == true){ //aprox. 21.027 segundos/927330
          enemyMove[10] = true;
        }
     }

    void moveEnemies(){
        for(int i = 0; i < enemiesNumber; i++){
              if(enemyMove[i] == true ){
                if(enemies[i] != null){
                    enemies[i].transform.Translate(new Vector3(enemyVelocity,0,0) * Time.deltaTime);
                }
                else{
                    Debug.Log("Dead "+i);
                } 
            }
        }
        /*
        if(enemyMove[0] == true ){
            if(enemies[0] != null){
                enemies[0].transform.Translate(new Vector3(enemyVelocity,0,0) * Time.deltaTime);
            }
            else{
                //Debug.Log("Dead");
            } 
        }*/
    }


}


