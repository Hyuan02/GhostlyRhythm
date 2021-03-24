using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyObject;
    private int enemiesNumber = 300; // ATENÇÃO PARA ESSE NUMERO
    private GameObject[] enemies = new GameObject[300];

    private bool[] enemySpawn = new bool[300]; 
    private bool[] enemyMove = new bool[300]; 

    AudioSource audioSource;
    
    private  float[] posY = new float[] { 3f,1.5f, 0, -1.5f, -3f };

    private float enemyZ, enemyX;
    private int enemyVelocity = -15;

    private float enemyOffsetX = 13f;
    [SerializeField]
    private GameObject movingDolly = null;
    float contadorSpawn1 = 62f;
    float contadorSpawn2 = 70.5f;
    float contadorSpawn3 = 79f;
    private int cena = 1;
    
    private  float[] fase2Move= new float[] { 
      16f, 16.5f, 19.1f, 19.5f, 35.9f, 36.3f, 36.6f, 36.8f, 37.6f, 37.9f,
      38.2f, 38.5f, 39.1f, 39.4f, 39.8f, 40.1f, 40.9f, 41.2f, 41.5f, 41.7f,
      42.1f, 42.5f, 42.8f, 43.2f, 43.4f, 44.1f, 44.5f, 44.8f, 45.5f, 45.6f,
      45.9f, 46.1f, 46.4f, 46.7f, 47.4f, 47.8f, 48.1f, 48.3f, 49.1f, 49.5f,
      49.7f, 49.9f, 50.7f, 51.0f, 51.4f, 51.6f, 52.2f, 52.5f, 52.7f, 53.0f,
      53.2f, 54.1f, 54.3f, 54.7f, 55.3f, 55.9f, 56.3f, 57.3f, 57.6f, 57.9f,
      58.1f, 58.3f, 58.7f, 58.8f, 59.4f, 59.7f, 59.9f, 60.8f, 61.1f, 61.4f,
      61.6f, 62.4f, 62.7f, 63.0f, 63.2f, 64.0f, 64.4f, 64.7f, 64.9f, 65.5f,
      65.7f, 66.0f, 66.3f, 66.5f, 66.7f, 66.9f, 67.3f, 67.6f, 68.0f, 68.2f,
      68.6f, 69.0f, 69.3f, 69.6f, 70.2f, 70.4f, 70.6f, 70.9f, 71.2f, 71.5f,
      71.9f, 72.0f, 72.1f, 72.3f, 72.6f, 72.9f, 73.1f, 73.5f, 73.9f, 74.2f, 
      74.5f, 74.7f, 75.6f, 75.9f, 76.2f, 76.4f, 76.8f, 77.2f, 77.5f, 77.8f,
      78.0f, 78.6f, 78.9f, 79.2f, 79.5f, 79.7f, 80.1f, 80.5f, 80.8f, 81.1f,
      81.3f, 81.7f, 82.1f, 82.5f, 82.8f, 83.0f, 83.4f, 83.8f, 84.1f, 84.4f,
      84.6f, 85.0f, 85.4f, 85.7f, 86.0f, 86.2f, 86.6f, 87.1f, 87.4f, 87.7f,
      87.9f, 88.7f, 89.0f, 89.1f, 89.3f, 89.5f, 89.9f, 90.4f, 90.8f, 91.0f,
      91.2f, 92.0f, 92.3f, 92.6f, 92.8f, 93.6f, 94.0f, 94.3f, 94.5f, 94.9f,
      95.3f, 95.6f, 95.9f, 96.1f, 96.9f, 97.2f, 97.5f, 97.8f, 98.2f, 98.6f,
      98.9f, 99.2f, 99.4f, 100.2f, 100.5f, 100.8f, 101.0, 101.9f, 102.2f, 102.5f,
      102.7f, 103.5f, 103.8f, 104.1f, 104.3f, 104.9f, 105.2f, 105.5f, 105.8f, 106f,
      106.8f, 107.1f, 107.4f, 107.6f, 108f, 108.4f, 108.7f, 109.1f, 109.3f, 110.1f,
      110.4f, 110.7f, 110.9f, 111.3f, 111.7f, 112f, 112.3f, 112.6f, 113.4f, 113.7f,
      114f, 114.2f, 115f, 115.3f, 115.6f, 115.8f, 116.7f, 117f, 117.3f, 117.5f, 118.1f  
      };
    private float spawnTimer =2f;

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
    void FixedUpdate()
    {
        //Debug.Log(audioSource.timeSamples);  
        spawnEnemies();
        moveTriggerEnemies();
        moveEnemies();
    }

   

    void spawnEnemies(){
        var enemyY = TrailsManager.instance.OccupiedTrail.trailObject.transform.position.y;

       if(cena ==0){
          if(audioSource.timeSamples >= 617164 && enemySpawn[0] == false){   //aprox. 14 segundos/617400 
            enemies[0] = SpawnEnemy();
            enemySpawn[0] = true;
          }
          if(audioSource.timeSamples >= 639743 && enemySpawn[1] == false){   //aprox. 14.5 segundos/651450 
            enemies[1] = SpawnEnemy();
            enemySpawn[1] = true;
          }
          if(audioSource.timeSamples >=651974 && enemySpawn[2] == false){   //aprox. 15.0 segundos/661500 
            enemies[2] = SpawnEnemy();
            enemySpawn[2] = true;
          }
          if(audioSource.timeSamples >= 683961 && enemySpawn[3] == false){   //aprox. 15.5 segundos/683550 
            enemies[3] = SpawnEnemy();
            enemySpawn[3] = true;
          }
          if(audioSource.timeSamples >= 705599 && enemySpawn[4] == false){   //aprox. 16 segundos/705600
            enemies[4] = SpawnEnemy();
            enemySpawn[4] = true;
          }
          if(audioSource.timeSamples >= 727238 && enemySpawn[5] == false){   //aprox. 16.5 segundos/727650
            enemies[5] = SpawnEnemy();
            enemySpawn[5] = true;
          }
          if(audioSource.timeSamples >= 749817 && enemySpawn[6] == false){   //aprox. 17 segundos/749700
            enemies[6] = SpawnEnemy();
            enemySpawn[6] = true;
          }
          if(audioSource.timeSamples >= 771455 && enemySpawn[7] == false){   //aprox. 17.5 segundos/771750
            enemies[7] = SpawnEnemy();
            enemySpawn[7] = true;
          }
          if(audioSource.timeSamples >= 794035 && enemySpawn[8] == false){   //aprox. 18 segundos/793800
            enemies[8] = SpawnEnemy();
            enemySpawn[8] = true;
          }
          if(audioSource.timeSamples >= 815673 && enemySpawn[9] == false){   //aprox. 18.5 segundos/815850
            enemies[9] = SpawnEnemy();
            enemySpawn[9] = true;
          }
          if(audioSource.timeSamples >= 838252 && enemySpawn[10] == false){   //aprox. 19 segundos/837900
            enemies[10] = SpawnEnemy();
            enemySpawn[10] = true;
          }
          
          if(audioSource.timeSamples >= 859950 && enemySpawn[11] == false){   //aprox. 14 segundos/617400 
            enemies[11] = SpawnEnemy();
            enemySpawn[11] = true;
          }
          if(audioSource.timeSamples >= 884546 && enemySpawn[12] == false){   //aprox. 14.5 segundos/651450 
            enemies[12] = SpawnEnemy();
            enemySpawn[12] = true;
          }
          if(audioSource.timeSamples >= 905280 && enemySpawn[13] == false){   //aprox. 15.0 segundos/661500 
            enemies[13] = SpawnEnemy();
            enemySpawn[13] = true;
          }
          if(audioSource.timeSamples >= 927330 && enemySpawn[14] == false){   //aprox. 15.5 segundos/683550 
            enemies[14] = SpawnEnemy();
            enemySpawn[14] = true;
          }
          if(audioSource.timeSamples >= 950610 && enemySpawn[15] == false){   //aprox. 16 segundos/705600
            enemies[15] = SpawnEnemy();
            enemySpawn[15] = true;
          }
          if(audioSource.timeSamples >= 972660 && enemySpawn[16] == false){   //aprox. 16.5 segundos/727650
            enemies[16] = SpawnEnemy();
            enemySpawn[16] = true;
          }
          if(audioSource.timeSamples >= 992250 && enemySpawn[17] == false){   //aprox. 17 segundos/749700
            enemies[17] = SpawnEnemy();
            enemySpawn[17] = true;
          }
          if(audioSource.timeSamples >= 1016760 && enemySpawn[18] == false){   //aprox. 17.5 segundos/771750
            enemies[18] = SpawnEnemy();
            enemySpawn[18] = true;
          }
          if(audioSource.timeSamples >= 1036350 && enemySpawn[19] == false){   //aprox. 18 segundos/793800
            enemies[19] = SpawnEnemy();
            enemySpawn[19] = true;
          }
          if(audioSource.timeSamples >= 1060860 && enemySpawn[20] == false){   //aprox. 18.5 segundos/815850
            enemies[20] = SpawnEnemy();
            enemySpawn[20] = true;
          }
          if(audioSource.timeSamples >= 1082910 && enemySpawn[21] == false){   //aprox. 19 segundos/837900
            enemies[21] = SpawnEnemy();
            enemySpawn[21] = true;
          }
          if(audioSource.timeSamples >= 1106189 && enemySpawn[22] == false){   //aprox. 14 segundos/617400 
            enemies[22] = SpawnEnemy();
            enemySpawn[22] = true;
          }
          if(audioSource.timeSamples >= 1127010 && enemySpawn[23] == false){   //aprox. 14.5 segundos/651450 
            enemies[23] = SpawnEnemy();
            enemySpawn[23] = true;
          }
          if(audioSource.timeSamples >= 1149060 && enemySpawn[24] == false){   //aprox. 15.0 segundos/661500 
            enemies[24] = SpawnEnemy();
            enemySpawn[24] = true;
          }
          if(audioSource.timeSamples >= 1171110 && enemySpawn[25] == false){   //aprox. 15.5 segundos/683550 
            enemies[25] = SpawnEnemy();
            enemySpawn[25] = true;
          }
          if(audioSource.timeSamples >= 1193160 && enemySpawn[26] == false){   //aprox. 16 segundos/705600
            enemies[26] = SpawnEnemy();
            enemySpawn[26] = true;
          }
          if(audioSource.timeSamples >= 1215210 && enemySpawn[27] == false){   //aprox. 16.5 segundos/727650
            enemies[27] = SpawnEnemy();
            enemySpawn[27] = true;
          }
          if(audioSource.timeSamples >= 1237260 && enemySpawn[28] == false){   //aprox. 17 segundos/749700
            enemies[28] = SpawnEnemy();
            enemySpawn[28] = true;
          }
          if(audioSource.timeSamples >= 1259310 && enemySpawn[29] == false){   //aprox. 17.5 segundos/771750
            enemies[29] = SpawnEnemy();
            enemySpawn[29] = true;
          }
          if(audioSource.timeSamples >= 1281360 && enemySpawn[30] == false){   //aprox. 18 segundos/793800
            enemies[30] = SpawnEnemy();
            enemySpawn[30] = true;
          }
          if(audioSource.timeSamples >= 1302180 && enemySpawn[31] == false){   //aprox. 18.5 segundos/815850
            enemies[31] = SpawnEnemy();
            enemySpawn[31] = true;
          }
          if(audioSource.timeSamples >= 1324230 && enemySpawn[32] == false){   //aprox. 19 segundos/837900
            enemies[32] = SpawnEnemy();
            enemySpawn[32] = true;
          }
          if(audioSource.timeSamples >= 1347510 && enemySpawn[33] == false){   //aprox. 14 segundos/617400 
            enemies[33] = SpawnEnemy();
            enemySpawn[33] = true;
          }
          if(audioSource.timeSamples >=  1369560 && enemySpawn[34] == false){   //aprox. 14.5 segundos/651450 
            enemies[34] = SpawnEnemy();
            enemySpawn[34] = true;
          }
          if(audioSource.timeSamples >=  1390380 && enemySpawn[35] == false){   //aprox. 15.0 segundos/661500 
            enemies[35] = SpawnEnemy();
            enemySpawn[35] = true;
          }
          if(audioSource.timeSamples >= 1413660  && enemySpawn[36] == false){   //aprox. 15.5 segundos/683550 
            enemies[36] = SpawnEnemy();
            enemySpawn[36] = true;
          }
          if(audioSource.timeSamples >= 1436939  && enemySpawn[37] == false){   //aprox. 16 segundos/705600
            enemies[37] = SpawnEnemy();
            enemySpawn[37] = true;
          }
          if(audioSource.timeSamples >= 1436939  && enemySpawn[38] == false){   //aprox. 16.5 segundos/727650
            enemies[38] = SpawnEnemy();
            enemySpawn[38] = true;
          }
          if(audioSource.timeSamples >= 1478580  && enemySpawn[39] == false){   //aprox. 17 segundos/749700
            enemies[39] = SpawnEnemy();
            enemySpawn[39] = true;
          }
          if(audioSource.timeSamples >=  1501860  && enemySpawn[40] == false){   //aprox. 17.5 segundos/771750
            enemies[40] = SpawnEnemy();
            enemySpawn[40] = true;
          }
          if(audioSource.timeSamples >=  1522680  && enemySpawn[41] == false){   //aprox. 18 segundos/793800
            enemies[41] = SpawnEnemy();
            enemySpawn[41] = true;
          }
          if(audioSource.timeSamples >= 1545960 && enemySpawn[42] == false){   //aprox. 18.5 segundos/815850
            enemies[42] = SpawnEnemy();
            enemySpawn[42] = true;
          }
          if(audioSource.timeSamples >= 1568010 && enemySpawn[43] == false){   //aprox. 19 segundos/837900
            enemies[43] = SpawnEnemy();
            enemySpawn[43] = true;
          }
          if(audioSource.timeSamples >= 1587600 && enemySpawn[44] == false){   //aprox. 14 segundos/617400 
            enemies[44] = SpawnEnemy();
            enemySpawn[44] = true;
          }
          if(audioSource.timeSamples >= 1610880 && enemySpawn[45] == false){   //aprox. 14.5 segundos/651450 
            enemies[45] = SpawnEnemy();
            enemySpawn[45] = true;
          }
          if(audioSource.timeSamples >= 1632930 && enemySpawn[46] == false){   //aprox. 15.0 segundos/661500 
            enemies[46] = SpawnEnemy();
            enemySpawn[46] = true;
          }
          if(audioSource.timeSamples >= 1653750 && enemySpawn[47] == false){   //aprox. 15.5 segundos/683550 
            enemies[47] = SpawnEnemy();
            enemySpawn[47] = true;
          }
          if(audioSource.timeSamples >= 1678260 && enemySpawn[48] == false){   //aprox. 16 segundos/705600
            enemies[48] = SpawnEnemy();
            enemySpawn[48] = true;
          }
          if(audioSource.timeSamples >= 1700310 && enemySpawn[49] == false){   //aprox. 16.5 segundos/727650
            enemies[49] = SpawnEnemy();
            enemySpawn[49] = true;
          }
          if(audioSource.timeSamples >= 1721110 && enemySpawn[50] == false){   //aprox. 17 segundos/749700
            enemies[50] = SpawnEnemy();
            enemySpawn[50] = true;
          }
          if(audioSource.timeSamples >= 1744410 && enemySpawn[51] == false){   //aprox. 17.5 segundos/771750
            enemies[51] = SpawnEnemy();
            enemySpawn[51] = true;
          }
          if(audioSource.timeSamples >= 1766460 && enemySpawn[52] == false){   //PRATOS!!!!!!
            enemies[52] = SpawnEnemy();
            enemySpawn[52] = true;
          }
          if(audioSource.timeSamples >= 1786050 && enemySpawn[53] == false){   //aprox. 14 segundos/617400 
            enemies[53] = SpawnEnemy();
            enemySpawn[53] = true;
          }
          if(audioSource.timeSamples >= 1810560 && enemySpawn[54] == false){   //aprox. 14.5 segundos/651450 
            enemies[54] = SpawnEnemy();
            enemySpawn[54] = true;
          }
          if(audioSource.timeSamples >= 1830150 && enemySpawn[55] == false){   //aprox. 15.0 segundos/661500 
            enemies[55] = SpawnEnemy();
            enemySpawn[55] = true;
          }
          if(audioSource.timeSamples >= 1853430 && enemySpawn[56] == false){   //aprox. 15.5 segundos/683550 
            enemies[56] = SpawnEnemy();
            enemySpawn[56] = true;
          }
          if(audioSource.timeSamples >= 1876710 && enemySpawn[57] == false){   //aprox. 16 segundos/705600
            enemies[57] = SpawnEnemy();
            enemySpawn[57] = true;
          }
          if(audioSource.timeSamples >= 1898760 && enemySpawn[58] == false){   //aprox. 16.5 segundos/727650
            enemies[58] = SpawnEnemy();
            enemySpawn[58] = true;
          }
          if(audioSource.timeSamples >= 1918350 && enemySpawn[59] == false){   //aprox. 17 segundos/749700
            enemies[59] = SpawnEnemy();
            enemySpawn[59] = true;
          }
          if(audioSource.timeSamples >= 1941630 && enemySpawn[60] == false){   //aprox. 18 segundos/793800
            enemies[60] = SpawnEnemy();
            enemySpawn[60] = true;
          }
          if(audioSource.timeSamples >= 1962450 && enemySpawn[61] == false){   //aprox. 18.5 segundos/815850
            enemies[61] = SpawnEnemy();
            enemySpawn[61] = true;
          }
          if(audioSource.timeSamples >= 1986960 && enemySpawn[62] == false){   //aprox. 19 segundos/837900
            enemies[62] = SpawnEnemy();
            enemySpawn[62] = true;
          }
          if(audioSource.timeSamples >= 2006550 && enemySpawn[63] == false){   //aprox. 17.5 segundos/771750
            enemies[63] = SpawnEnemy();
            enemySpawn[63] = true;
          }
          
        if(audioSource.timeSamples >= 2160900 && enemySpawn[64] == false){   //aprox. 51 segundos
            enemies[64] = SpawnEnemy();
            enemySpawn[64] = true;
          }
          if(audioSource.timeSamples >= 2373627 && enemySpawn[65] == false){   //aprox. 55.8 segundos
            enemies[65] = SpawnEnemy();
            enemySpawn[65] = true;
          }
          if(audioSource.timeSamples >= 2550744 && enemySpawn[66] == false){   //aprox. 59 segundos
            enemies[66] = SpawnEnemy();
            enemySpawn[66] = true;
          }
          
          for(int i = 67; i<=84; i++ ){
              if(audioSource.time >= contadorSpawn1 && enemySpawn[i] == false){   
              //aprox. 59 segundos
              
              enemies[i] = SpawnEnemy();
              contadorSpawn1 += 0.5f;
              enemySpawn[i] = true;
              
            }
        }
          
         

            for(int j = 86; j<=99; j++ ){
              if(audioSource.time >= contadorSpawn2 && enemySpawn[j] == false){   
              //aprox. 59 segundos
              
              enemies[j] = SpawnEnemy();
              contadorSpawn2 += 0.5f;
              enemySpawn[j] = true;
              
            }
          }
          
          if(audioSource.timeSamples >= 3439800 && enemySpawn[100] == false){   //aprox. 1:18 segundos
            enemies[100] = SpawnEnemy();
            enemySpawn[100] = true;
          }
          
        
          
          for(int l = 101; l<=131; l++ ){
              if(audioSource.time >= contadorSpawn3 && enemySpawn[l] == false){   
              //aprox. 59 segundos
              
              enemies[l] = SpawnEnemy();
              contadorSpawn3 += 0.5f;
              enemySpawn[l] = true;
              
            }
        }
  }       
      
      if(cena == 1){
           for(int i = 0; i < fase2Move.Length; i++ ){
              if(audioSource.time >= (fase2Move[i]-spawnTimer) && enemySpawn[i] == false){ 
              
              enemies[i] = SpawnEnemy();
              enemySpawn[i] = true;
              
            }
      
        }

  
      
    }
  }
    /*
    0 aprox. 16 segundos/705600 
    1 aprox. 16.5 segundos/750930    
    2 aprox. 17.27 segundos/750930
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
    31 aprox. 31.555 segundos/1390380	
    32 aprox. 32.083 segundos/1413660
    33 aprox. 32.583 segundos/1436939
    34 aprox. 33.055 segundos/1457760 	
    35 aprox. 33.5 segundos/1478580
    36 aprox. 34 segundos/1501860
    37 aprox. 34.5 segundos/1522680
    38 aprox. 35.055 segundos/1545960
    39 aprox. 35.5 segundos/1568010
    40 aprox. 36 segundos/1587600
    41 aprox. 36.5 segundos/1610880
    42 aprox. 37.027 segundos/1632930
    43 aprox. 37.5 segundos/1653750
    44 aprox. 38 segundos/1678260
    45 aprox. 38.5 segundos/1700310
    46 aprox. 39 segundos/1721110
    47 aprox. 39.5 segundos/1744410  
    48 aprox. 40 segundos/1766460 PRATOS
    49 aprox. 40.5 segundos/1786050
    50 aprox. 41 segundos/1810560
    51 aprox. 41.5 segundos/1830150
    52 aprox. 42 segundos/1853430
    53 aprox. 42.5 segundos/1876710
    54 aprox. 43.055 segundos/1898760
    55 aprox. 43.5 segundos/1918350
    56 aprox. 44 segundos/1941630
    57 aprox. 44.5 segundos/1962450
    58 aprox. 45 segundos/1986960
    59 aprox. 45.5 segundos/2006550
    60 aprox. 46 segundos/2028600
    61 aprox. 46.5 segundos/2053110
    62 aprox. 47 segundos/2073930
    63 aprox. 47.5 segundos/2073930	
    		

    */
     void moveTriggerEnemies(){
       if(cena == 0){
          if(audioSource.timeSamples >= 708704 && enemySpawn[0] == true){ //aprox. 16.083 segundos/709283
            enemyMove[0] = true;
          }
          if(audioSource.timeSamples >= 731995 && enemySpawn[1] == true){ //aprox. 16.5 segundos/727650
            enemyMove[1] = true;
          }
            if(audioSource.timeSamples >= 754045 && enemySpawn[2] == true){ //aprox. 17.055 segundos/752160
            enemyMove[2] = true;
          }
          if(audioSource.timeSamples >= 775914 && enemySpawn[3] == true){ //aprox. 17.5 segundos/771750
            enemyMove[3] = true;
          }
          if(audioSource.timeSamples >= 798145 && enemySpawn[4] == true){ //aprox. 18.055 segundos/796260
            enemyMove[4] = true;
          }
          if(audioSource.timeSamples >= 820195 && enemySpawn[5] == true){ //aprox. 18.555 segundos/818310
            enemyMove[5] = true;
          }
          if(audioSource.timeSamples >= 842245 && enemySpawn[6] == true){ //aprox. 19.055 segundos/840360
            enemyMove[6] = true;
          }
          if(audioSource.timeSamples >= 864295 && enemySpawn[7] == true){ //aprox. 19.5   segundos/859950
            enemyMove[7] = true;
          }
          if(audioSource.timeSamples >= 885724 && enemySpawn[8] == true){ //aprox. 20.057 segundos/884546
            enemyMove[8] = true;
          }
          if(audioSource.timeSamples >= 908395 && enemySpawn[9] == true){ //aprox. 20.527 segundos/905280
            enemyMove[9] = true;
          }
          if(audioSource.timeSamples >= 929824 && enemySpawn[10] == true){ //aprox. 21.027 segundos/927330
            enemyMove[10] = true;
          }
          if(audioSource.timeSamples >= 951874 && enemySpawn[11] == true){ //aprox. 16.083 segundos/709283
            enemyMove[11] = true;
          }
          if(audioSource.timeSamples >= 973924 && enemySpawn[12] == true){ //aprox. 16.5 segundos/727650
            enemyMove[12] = true;
          }
            if(audioSource.timeSamples >= 995974 && enemySpawn[13] == true){ //aprox. 17.055 segundos/752160
            enemyMove[13] = true;
          }
          if(audioSource.timeSamples >= 1018645 && enemySpawn[14] == true){ //aprox. 17.5 segundos/771750
            enemyMove[14] = true;
          }
          if(audioSource.timeSamples >= 1040074 && enemySpawn[15] == true){ //aprox. 18.055 segundos/796260
            enemyMove[15] = true;
          }
          if(audioSource.timeSamples >= 1062745 && enemySpawn[16] == true){ //aprox. 18.555 segundos/818310
            enemyMove[16] = true;
          }
          if(audioSource.timeSamples >= 1084174 && enemySpawn[17] == true){ //aprox. 24.5
            enemyMove[17] = true;
          }
          if(audioSource.timeSamples >= 1106845 && enemySpawn[18] == true){ //aprox. 25
            enemyMove[18] = true;
          }
          if(audioSource.timeSamples >= 1128274 && enemySpawn[19] == true){ //aprox. 25.5
            enemyMove[19] = true;
          }
          if(audioSource.timeSamples >= 1150945 && enemySpawn[20] == true){ //aprox. 26.098 CERTO
            enemyMove[20] = true;
          }
          if(audioSource.timeSamples >= 1172374 && enemySpawn[21] == true){ //aprox. 26.5
            enemyMove[21] = true;
          }
          if(audioSource.timeSamples >= 1195045 && enemySpawn[22] == true){ //aprox. 16.083 segundos/709283
            enemyMove[22] = true;
          }
          if(audioSource.timeSamples >= 1215210 && enemySpawn[23] == true){ //aprox. 16.5 segundos/727650
            enemyMove[23] = true;
          }
            if(audioSource.timeSamples >= 1237260 && enemySpawn[24] == true){ //aprox. 17.055 segundos/752160
            enemyMove[24] = true;
          }
          if(audioSource.timeSamples >= 1259310 && enemySpawn[25] == true){ //aprox. 17.5 segundos/771750
            enemyMove[25] = true;
          }
          if(audioSource.timeSamples >= 1281360 && enemySpawn[26] == true){ //aprox. 18.055 segundos/796260
            enemyMove[26] = true;
          }
          if(audioSource.timeSamples >= 1302180 && enemySpawn[27] == true){ //aprox. 18.555 segundos/818310
            enemyMove[27] = true;
          }
          if(audioSource.timeSamples >= 1324230 && enemySpawn[28] == true){ //aprox. 19.055 segundos/840360
            enemyMove[28] = true;
          }
          if(audioSource.timeSamples >= 1347510 && enemySpawn[29] == true){ //aprox. 19.5   segundos/859950
            enemyMove[29] = true;
          }
          if(audioSource.timeSamples >= 1369560 && enemySpawn[30] == true){ //aprox. 20.057 segundos/884546
            enemyMove[30] = true;
          }
          if(audioSource.timeSamples >= 1390380 && enemySpawn[31] == true){ //aprox. 20.527 segundos/905280
            enemyMove[31] = true;
          }
          if(audioSource.timeSamples >= 1413660 && enemySpawn[32] == true){ //aprox. 21.027 segundos/927330
            enemyMove[32] = true;
          }
          if(audioSource.timeSamples >= 1436939 && enemySpawn[33] == true){ //aprox. 16.083 segundos/709283
            enemyMove[33] = true;
          }
          if(audioSource.timeSamples >= 1457760 && enemySpawn[34] == true){ //aprox. 16.5 segundos/727650
            enemyMove[34] = true;
          }
            if(audioSource.timeSamples >= 1478580 && enemySpawn[35] == true){ //aprox. 17.055 segundos/752160
            enemyMove[35] = true;
          }
          if(audioSource.timeSamples >= 1501860 && enemySpawn[36] == true){ //aprox. 17.5 segundos/771750
            enemyMove[36] = true;
          }
          if(audioSource.timeSamples >= 1522680 && enemySpawn[37] == true){ //aprox. 18.055 segundos/796260
            enemyMove[37] = true;
          }
          if(audioSource.timeSamples >= 1545960 && enemySpawn[38] == true){ //aprox. 18.555 segundos/818310
            enemyMove[38] = true;
          }
          if(audioSource.timeSamples >= 1568010 && enemySpawn[39] == true){ //aprox. 19.055 segundos/840360
            enemyMove[39] = true;
          }
          if(audioSource.timeSamples >= 1587600 && enemySpawn[40] == true){ //aprox. 19.5   segundos/859950
            enemyMove[40] = true;
          }
          if(audioSource.timeSamples >= 1610880 && enemySpawn[41] == true){ //aprox. 20.057 segundos/884546
            enemyMove[41] = true;
          }
          if(audioSource.timeSamples >= 1632930 && enemySpawn[42] == true){ //aprox. 20.527 segundos/905280
            enemyMove[42] = true;
          }
          if(audioSource.timeSamples >= 1653750 && enemySpawn[43] == true){ //aprox. 21.027 segundos/927330
            enemyMove[43] = true;
          }
          if(audioSource.timeSamples >= 1678260 && enemySpawn[44] == true){ //aprox. 16.083 segundos/709283
            enemyMove[44] = true;
          }
          if(audioSource.timeSamples >= 1700310 && enemySpawn[45] == true){ //aprox. 16.5 segundos/727650
            enemyMove[45] = true;
          }
            if(audioSource.timeSamples >= 1721110 && enemySpawn[46] == true){ //aprox. 17.055 segundos/752160
            enemyMove[46] = true;
          }
          if(audioSource.timeSamples >= 1744410 && enemySpawn[47] == true){ //aprox. 17.5 segundos/771750
            enemyMove[47] = true;
          }
          if(audioSource.timeSamples >= 1766460 && enemySpawn[48] == true){ //aprox. 18.055 segundos/796260
            enemyMove[48] = true;
          }
          if(audioSource.timeSamples >= 1786050 && enemySpawn[49] == true){ //aprox. 18.555 segundos/818310
            enemyMove[49] = true;
          }
          if(audioSource.timeSamples >= 1810560 && enemySpawn[50] == true){ //aprox. 19.055 segundos/840360
            enemyMove[50] = true;
          }
          if(audioSource.timeSamples >= 1830150 && enemySpawn[51] == true){ //aprox. 19.5   segundos/859950
            enemyMove[51] = true;
          }
          if(audioSource.timeSamples >= 1853430 && enemySpawn[52] == true){ //aprox. 20.057 segundos/884546
            enemyMove[52] = true;
          }
          if(audioSource.timeSamples >= 1876710 && enemySpawn[53] == true){ //aprox. 20.527 segundos/905280
            enemyMove[53] = true;
          }
          if(audioSource.timeSamples >= 1898760 && enemySpawn[54] == true){ //aprox. 21.027 segundos/927330
            enemyMove[54] = true;
          }
          if(audioSource.timeSamples >= 1918350 && enemySpawn[55] == true){ //aprox. 16.083 segundos/709283
            enemyMove[55] = true;
          }
          if(audioSource.timeSamples >= 1941630 && enemySpawn[56] == true){ //aprox. 16.5 segundos/727650
            enemyMove[56] = true;
          }
            if(audioSource.timeSamples >= 1962450 && enemySpawn[57] == true){ //aprox. 17.055 segundos/752160
            enemyMove[57] = true;
          }
          if(audioSource.timeSamples >= 1986960 && enemySpawn[58] == true){ //aprox. 17.5 segundos/771750
            enemyMove[58] = true;
          }
          if(audioSource.timeSamples >= 2006550 && enemySpawn[59] == true){ //aprox. 18.055 segundos/796260
            enemyMove[59] = true;
          }
          if(audioSource.timeSamples >= 2028600 && enemySpawn[60] == true){ //aprox. 18.555 segundos/818310
            enemyMove[60] = true;
          }
          if(audioSource.timeSamples >= 2053110 && enemySpawn[61] == true){ //aprox. 19.055 segundos/840360
            enemyMove[61] = true;
          }
          if(audioSource.timeSamples >= 2073930 && enemySpawn[62] == true){ //aprox. 19.5   segundos/859950
            enemyMove[62] = true;
          }
          
          if(audioSource.timeSamples >= 2097210 && enemySpawn[63] == true){ 
            enemyMove[63] = true;
          }
          //frequencia do baixo inicio
          if(audioSource.timeSamples >= 2286993 && enemySpawn[64] == true){ //aprox. 51 segundos
            enemyMove[64] = true;
          }     
          if(audioSource.timeSamples >= 2462772 && enemySpawn[65] == true){ //aprox. 51 segundos
            enemyMove[65] = true;
          }     
          if(audioSource.timeSamples >= 2639793 && enemySpawn[66] == true){ //aprox. 59 segundos
            enemyMove[66] = true;
          }
          //fim frequencia baixo
          if(audioSource.timeSamples >= 2826124 && enemySpawn[67] == true){ //aprox. 1:04 segundos
            enemyMove[67] = true;
          }  
          if(audioSource.timeSamples >= 2826124 && enemySpawn[68] == true){ //aprox. 1:04 segundos
            enemyMove[68] = true;
          }  
            if(audioSource.timeSamples >= 2848795 && enemySpawn[69] == true){ //aprox. 1:04.5 segundos
            enemyMove[69] = true;
          }  
            if(audioSource.timeSamples >= 2870845 && enemySpawn[70] == true){ //aprox. 1:05 segundos
            enemyMove[70] = true;
          }  
            if(audioSource.timeSamples >= 2892895 && enemySpawn[71] == true){ //aprox. 1:05.5 segundos
            enemyMove[71] = true;
          }
            if(audioSource.timeSamples >= 2914324 && enemySpawn[72] == true){ //aprox. 1:06 segundos
            enemyMove[72] = true;
          }
            if(audioSource.timeSamples >= 2936374 && enemySpawn[73] == true){ //aprox. 1:06.5 segundos
            enemyMove[73] = true;
          }
          if(audioSource.timeSamples >= 2959045 && enemySpawn[74] == true){ //aprox. 1:07 segundos
            enemyMove[74] = true;
          }
          if(audioSource.timeSamples >= 2980474 && enemySpawn[75] == true){ //aprox. 1:07.5 segundos
            enemyMove[75] = true;
          }
          if(audioSource.timeSamples >= 3003766 && enemySpawn[76] == true){ //aprox. 1:08 segundos
            enemyMove[76] = true;
          }
          if(audioSource.timeSamples >= 3024574 && enemySpawn[77] == true){ //aprox. 1:08.5 segundos
            enemyMove[77] = true;
          }
          if(audioSource.timeSamples >= 3047245 && enemySpawn[78] == true){ //aprox. 1:09 segundos
            enemyMove[78] = true;
          }
          if(audioSource.timeSamples >= 3068054 && enemySpawn[79] == true){ //aprox. 1:09.5 segundos
            enemyMove[79] = true;
          }
          if(audioSource.timeSamples >= 3091345 && enemySpawn[80] == true){ //aprox. 1:10 segundos
            enemyMove[80] = true;
          }
          if(audioSource.timeSamples >= 3112774 && enemySpawn[81] == true){ //aprox. 1:10.5 segundos
            enemyMove[81] = true;
          }
          if(audioSource.timeSamples >= 3134824 && enemySpawn[82] == true){ //aprox. 1:11 segundos
            enemyMove[82] = true;
          }
          if(audioSource.timeSamples >= 3157495 && enemySpawn[83] == true){ //aprox. 1:11.5 segundos
            enemyMove[83] = true;
          }
          if(audioSource.timeSamples >= 3179545 && enemySpawn[84] == true){ //aprox. 1:12 segundos
            enemyMove[84] = true;
          }
          if(audioSource.timeSamples >= 3200974 && enemySpawn[86] == true){ //aprox. 1:12.5 segundos
            enemyMove[86] = true;
          }
          if(audioSource.timeSamples >= 3223645 && enemySpawn[87] == true){ //aprox. 1:13 segundos
            enemyMove[87] = true;
          }
          if(audioSource.timeSamples >= 3245074 && enemySpawn[88] == true){ //aprox. 1:13.5 segundos
            enemyMove[88] = true;
          }
          if(audioSource.timeSamples >= 3267745 && enemySpawn[89] == true){ //aprox. 1:14 segundos
            enemyMove[89] = true;
          }
          if(audioSource.timeSamples >= 3289174 && enemySpawn[90] == true){ //aprox. 1:14.5 segundos
            enemyMove[90] = true;
          }
          if(audioSource.timeSamples >= 3311845 && enemySpawn[91] == true){ //aprox. 1:15 segundos
            enemyMove[91] = true;
          }
          if(audioSource.timeSamples >= 3333895 && enemySpawn[92] == true){ //aprox. 1:15.5 segundos
            enemyMove[92] = true;
          }
          if(audioSource.timeSamples >= 3350359 && enemySpawn[93] == true){ //aprox. 1:16 segundos
            enemyMove[93] = true;
          }
          if(audioSource.timeSamples >= 3377374 && enemySpawn[94] == true){ //aprox. 1:16.5 segundos
            enemyMove[94] = true;
          }
          if(audioSource.timeSamples >= 3399424 && enemySpawn[95] == true){ //aprox. 1:17 segundos
            enemyMove[95] = true;
          }
          if(audioSource.timeSamples >= 3422095 && enemySpawn[96] == true){ //aprox. 1:17.5 segundos
            enemyMove[96] = true;
          }
          if(audioSource.timeSamples >= 3442904 && enemySpawn[97] == true){ //aprox. 1:18 segundos
            enemyMove[97] = true;
          }
          if(audioSource.timeSamples >= 3465574 && enemySpawn[98] == true){ //aprox. 1:18.5 segundos
            enemyMove[98] = true;
          }
          if(audioSource.timeSamples >= 3487004 && enemySpawn[99] == true){ //aprox. 1:19 segundos
            enemyMove[99] = true;
          }
          if(audioSource.timeSamples >= 3531104 && enemySpawn[100] == true){ //aprox. 1:20 segundos
            enemyMove[100] = true;
          }
          if(audioSource.timeSamples >= 3573962 && enemySpawn[101] == true){ //aprox. 1:21 segundos
            enemyMove[101] = true;
          }
          if(audioSource.timeSamples >= 3597874 && enemySpawn[102] == true){ //aprox. 1:21.5 segundos
            enemyMove[102] = true;
          }
          if(audioSource.timeSamples >= 3619304 && enemySpawn[103] == true){ //aprox. 1:22 segundos
            enemyMove[103] = true;
          }
          if(audioSource.timeSamples >= 3641354 && enemySpawn[104] == true){ //aprox. 1:22.5 segundos
            enemyMove[104] = true;
          }
          if(audioSource.timeSamples >= 3664024 && enemySpawn[105] == true){ //aprox. 1:23 segundos
            enemyMove[105] = true;
          }
          if(audioSource.timeSamples >= 3686074 && enemySpawn[106] == true){ //aprox. 1:23.5 segundos
            enemyMove[106] = true;
          }
          if(audioSource.timeSamples >= 3707504 && enemySpawn[107] == true){ //aprox. 1:24 segundos
            enemyMove[107] = true;
          }
          if(audioSource.timeSamples >= 3730795 && enemySpawn[108] == true){ //aprox. 1:24.5 segundos
            enemyMove[108] = true;
          }
          if(audioSource.timeSamples >= 3752224 && enemySpawn[109] == true){ //aprox. 1:25 segundos
            enemyMove[109] = true;
          }
          if(audioSource.timeSamples >= 3774895 && enemySpawn[110] == true){ //aprox. 1:25.5 segundos
            enemyMove[110] = true;
          }
          if(audioSource.timeSamples >= 3796945  && enemySpawn[111] == true){ //aprox. 1:26 segundos
            enemyMove[111] = true;
          }
          if(audioSource.timeSamples >= 3818995  && enemySpawn[112] == true){ //aprox. 1:26.5 segundos
            enemyMove[112] = true;
          }
          if(audioSource.timeSamples >= 3840424  && enemySpawn[113] == true){ //aprox. 1:27 segundos
            enemyMove[113] = true;
          }
          if(audioSource.timeSamples >= 3863095  && enemySpawn[114] == true){ //aprox. 1:27.5 segundos
            enemyMove[114] = true;
          }
          if(audioSource.timeSamples >= 3884524  && enemySpawn[115] == true){ //aprox. 1:28 segundos
            enemyMove[115] = true;
          }
          if(audioSource.timeSamples >= 3906574  && enemySpawn[116] == true){ //aprox. 1:28.5 segundos
            enemyMove[116] = true;
          }
          if(audioSource.timeSamples >= 3929245  && enemySpawn[117] == true){ //aprox. 1:29 segundos
            enemyMove[117] = true;
          }
          if(audioSource.timeSamples >= 3950674  && enemySpawn[118] == true){ //aprox. 1:29.5 segundos
            enemyMove[118] = true;
          }
          if(audioSource.timeSamples >= 3973345  && enemySpawn[119] == true){ //aprox. 1:30 segundos
            enemyMove[119] = true;
          }
          if(audioSource.timeSamples >= 3994174  && enemySpawn[120] == true){ //aprox. 1:30.5 segundos
            enemyMove[120] = true;
          }
          if(audioSource.timeSamples >= 4017445  && enemySpawn[121] == true){ //aprox. 1:31 segundos
            enemyMove[121] = true;
          }
          if(audioSource.timeSamples >= 4038874  && enemySpawn[122] == true){ //aprox. 1:31.5 segundos
            enemyMove[122] = true;
          }
          if(audioSource.timeSamples >= 4054717  && enemySpawn[123] == true){ //aprox. 1:31.9 segundos
            enemyMove[123] = true;
          }
          if(audioSource.timeSamples >= 4082354  && enemySpawn[124] == true){ //aprox. 1:32.5 segundos
            enemyMove[124] = true;
          }
          if(audioSource.timeSamples >= 4105024  && enemySpawn[125] == true){ //aprox. 1:33 segundos
            enemyMove[125] = true;
          }
          if(audioSource.timeSamples >= 4127074  && enemySpawn[126] == true){ //aprox. 1:33.5 segundos
            enemyMove[126] = true;
          }
          if(audioSource.timeSamples >= 4149124  && enemySpawn[127] == true){ //aprox. 1:34 segundos
            enemyMove[127] = true;
          }
          if(audioSource.timeSamples >= 4171174 && enemySpawn[128] == true){ //aprox. 1:34.5 segundos
            enemyMove[128] = true;
          }
          if(audioSource.timeSamples >= 4193224 && enemySpawn[129] == true){ //aprox. 1:35 segundos
            enemyMove[129] = true;
          }
          if(audioSource.timeSamples >= 4215274 && enemySpawn[130] == true){ //aprox. 1:35.5 segundos
            enemyMove[130] = true;
          }
          if(audioSource.timeSamples >= 4237234 && enemySpawn[131] == true){ //aprox. 1:36 segundos
            enemyMove[131] = true;
          }
      }

      if(cena == 1){
        
            for(int i = 0; i <  fase2Move.Length; i++ ){
              if(audioSource.time >= fase2Move[i] && enemySpawn[i] == true){   
                 enemyMove[i] = true;
              
            }
           }
      }

     }

    void moveEnemies(){
        for(int i = 0; i < enemiesNumber; i++){
              if(enemyMove[i] == true ){
                if(enemies[i] != null){
                    enemies[i].transform.Translate(new Vector3(enemyVelocity,0,0) * Time.deltaTime);
                   
                }
                else{
                   // Debug.Log("Dead "+i);
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


    GameObject SpawnEnemy()
    {

        
        var random_or_follow_player = Random.Range(0f, 1f);
        float enemyY;

        if (random_or_follow_player > 0.65)
        {
            var random_or_probable = Random.Range(0f, 1f);
            if (random_or_probable > 0.60)
            {
                var trails = TrailsManager.instance.ProbableTrails;
                enemyY = trails[Random.Range(0, trails.Length)].trailObject.transform.position.y;
            }
            else
            {
                var trails = TrailsManager.instance.EmptyTrails;
                enemyY = trails[Random.Range(0, trails.Length)].trailObject.transform.position.y;
            }
        }
        else
        {
            enemyY = TrailsManager.instance.OccupiedTrail.trailObject.transform.position.y;
        }
        

        //var enemyY = TrailsManager.instance.OccupiedTrail.trailObject.transform.position.y;

        var gameObjectNew = Instantiate(enemyObject, this.transform);
        gameObjectNew.transform.position = new Vector3(movingDolly.transform.position.x + enemyOffsetX, enemyY, enemyZ);
        return gameObjectNew;
    }

    public void ResetVectors()
    {
        enemySpawn = new bool[300];
        enemyMove = new bool[300];
        contadorSpawn1 = 62f;
        contadorSpawn2 = 70.5f;
        contadorSpawn3 = 79f;
    }

}


