using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyObject;
    public int enemiesNumber = 64; // ATENÇÃO PARA ESSE NUMERO
    private GameObject[] enemies = new GameObject[64];

    private bool[] enemySpawn = new bool[64]; 
    private bool[] enemyMove = new bool[64]; 

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
        //var enemyY = TrailsManager.instance.OccupiedTrail.trailObject.transform.position.y;

        //Debug.Log(enemyY);
        var enemyY = posY[Random.Range(0,5)];
        if(audioSource.timeSamples >= 617164 && enemySpawn[0] == false){   //aprox. 14 segundos/617400 
           enemies[0] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[0] = true;
        }
        if(audioSource.timeSamples >= 639743 && enemySpawn[1] == false){   //aprox. 14.5 segundos/651450 
           enemies[1] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[1] = true;
        }
        if(audioSource.timeSamples >=651974 && enemySpawn[2] == false){   //aprox. 15.0 segundos/661500 
           enemies[2] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[2] = true;
        }
        if(audioSource.timeSamples >= 683961 && enemySpawn[3] == false){   //aprox. 15.5 segundos/683550 
           enemies[3] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[3] = true;
        }
        if(audioSource.timeSamples >= 705599 && enemySpawn[4] == false){   //aprox. 16 segundos/705600
           enemies[4] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[4] = true;
        }
        if(audioSource.timeSamples >= 727238 && enemySpawn[5] == false){   //aprox. 16.5 segundos/727650
           enemies[5] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[5] = true;
        }
        if(audioSource.timeSamples >= 749817 && enemySpawn[6] == false){   //aprox. 17 segundos/749700
           enemies[6] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[6] = true;
        }
        if(audioSource.timeSamples >= 771455 && enemySpawn[7] == false){   //aprox. 17.5 segundos/771750
           enemies[7] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[7] = true;
        }
        if(audioSource.timeSamples >= 794035 && enemySpawn[8] == false){   //aprox. 18 segundos/793800
           enemies[8] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[8] = true;
        }
        if(audioSource.timeSamples >= 815673 && enemySpawn[9] == false){   //aprox. 18.5 segundos/815850
           enemies[9] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[9] = true;
        }
         if(audioSource.timeSamples >= 838252 && enemySpawn[10] == false){   //aprox. 19 segundos/837900
           enemies[10] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[10] = true;
        }
         
         if(audioSource.timeSamples >= 859950 && enemySpawn[11] == false){   //aprox. 14 segundos/617400 
           enemies[11] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[11] = true;
        }
        if(audioSource.timeSamples >= 884546 && enemySpawn[12] == false){   //aprox. 14.5 segundos/651450 
           enemies[12] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[12] = true;
        }
        if(audioSource.timeSamples >= 905280 && enemySpawn[13] == false){   //aprox. 15.0 segundos/661500 
           enemies[13] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[13] = true;
        }
        if(audioSource.timeSamples >= 927330 && enemySpawn[14] == false){   //aprox. 15.5 segundos/683550 
           enemies[14] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[14] = true;
        }
        if(audioSource.timeSamples >= 950610 && enemySpawn[15] == false){   //aprox. 16 segundos/705600
           enemies[15] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[15] = true;
        }
        if(audioSource.timeSamples >= 972660 && enemySpawn[16] == false){   //aprox. 16.5 segundos/727650
           enemies[16] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[16] = true;
        }
        if(audioSource.timeSamples >= 992250 && enemySpawn[17] == false){   //aprox. 17 segundos/749700
           enemies[17] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[17] = true;
        }
        if(audioSource.timeSamples >= 1016760 && enemySpawn[18] == false){   //aprox. 17.5 segundos/771750
           enemies[18] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[18] = true;
        }
        if(audioSource.timeSamples >= 1036350 && enemySpawn[19] == false){   //aprox. 18 segundos/793800
           enemies[19] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[19] = true;
        }
        if(audioSource.timeSamples >= 1060860 && enemySpawn[20] == false){   //aprox. 18.5 segundos/815850
           enemies[20] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[20] = true;
        }
         if(audioSource.timeSamples >= 1082910 && enemySpawn[21] == false){   //aprox. 19 segundos/837900
           enemies[21] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[21] = true;
        }
         if(audioSource.timeSamples >= 1106189 && enemySpawn[22] == false){   //aprox. 14 segundos/617400 
           enemies[22] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[22] = true;
        }
        if(audioSource.timeSamples >= 1127010 && enemySpawn[23] == false){   //aprox. 14.5 segundos/651450 
           enemies[23] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[23] = true;
        }
        if(audioSource.timeSamples >= 1149060 && enemySpawn[24] == false){   //aprox. 15.0 segundos/661500 
           enemies[24] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[24] = true;
        }
        if(audioSource.timeSamples >= 1171110 && enemySpawn[25] == false){   //aprox. 15.5 segundos/683550 
           enemies[25] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[25] = true;
        }
        if(audioSource.timeSamples >= 1193160 && enemySpawn[26] == false){   //aprox. 16 segundos/705600
           enemies[26] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[26] = true;
        }
        if(audioSource.timeSamples >= 1215210 && enemySpawn[27] == false){   //aprox. 16.5 segundos/727650
           enemies[27] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[27] = true;
        }
        if(audioSource.timeSamples >= 1237260 && enemySpawn[28] == false){   //aprox. 17 segundos/749700
           enemies[28] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[28] = true;
        }
        if(audioSource.timeSamples >= 1259310 && enemySpawn[29] == false){   //aprox. 17.5 segundos/771750
           enemies[29] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[29] = true;
        }
        if(audioSource.timeSamples >= 1281360 && enemySpawn[30] == false){   //aprox. 18 segundos/793800
           enemies[30] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[30] = true;
        }
        if(audioSource.timeSamples >= 1302180 && enemySpawn[31] == false){   //aprox. 18.5 segundos/815850
           enemies[31] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[31] = true;
        }
         if(audioSource.timeSamples >= 1324230 && enemySpawn[32] == false){   //aprox. 19 segundos/837900
           enemies[32] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[32] = true;
        }
         if(audioSource.timeSamples >= 1347510 && enemySpawn[33] == false){   //aprox. 14 segundos/617400 
           enemies[33] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[33] = true;
        }
        if(audioSource.timeSamples >=  1369560 && enemySpawn[34] == false){   //aprox. 14.5 segundos/651450 
           enemies[34] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[34] = true;
        }
        if(audioSource.timeSamples >=  1390380 && enemySpawn[35] == false){   //aprox. 15.0 segundos/661500 
           enemies[35] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[35] = true;
        }
        if(audioSource.timeSamples >= 1413660  && enemySpawn[36] == false){   //aprox. 15.5 segundos/683550 
           enemies[36] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[36] = true;
        }
        if(audioSource.timeSamples >= 1436939  && enemySpawn[37] == false){   //aprox. 16 segundos/705600
           enemies[37] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[37] = true;
        }
        if(audioSource.timeSamples >= 1436939  && enemySpawn[38] == false){   //aprox. 16.5 segundos/727650
           enemies[38] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[38] = true;
        }
        if(audioSource.timeSamples >= 1478580  && enemySpawn[39] == false){   //aprox. 17 segundos/749700
           enemies[39] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[39] = true;
        }
        if(audioSource.timeSamples >=  1501860  && enemySpawn[40] == false){   //aprox. 17.5 segundos/771750
           enemies[40] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[40] = true;
        }
        if(audioSource.timeSamples >=  1522680  && enemySpawn[41] == false){   //aprox. 18 segundos/793800
           enemies[41] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[41] = true;
        }
        if(audioSource.timeSamples >= 1545960 && enemySpawn[42] == false){   //aprox. 18.5 segundos/815850
           enemies[42] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[42] = true;
        }
         if(audioSource.timeSamples >= 1568010 && enemySpawn[43] == false){   //aprox. 19 segundos/837900
           enemies[43] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[43] = true;
        }
         if(audioSource.timeSamples >= 1587600 && enemySpawn[44] == false){   //aprox. 14 segundos/617400 
           enemies[44] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[44] = true;
        }
        if(audioSource.timeSamples >= 1610880 && enemySpawn[45] == false){   //aprox. 14.5 segundos/651450 
           enemies[45] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[45] = true;
        }
        if(audioSource.timeSamples >= 1632930 && enemySpawn[46] == false){   //aprox. 15.0 segundos/661500 
           enemies[46] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[46] = true;
        }
        if(audioSource.timeSamples >= 1653750 && enemySpawn[47] == false){   //aprox. 15.5 segundos/683550 
           enemies[47] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[47] = true;
        }
        if(audioSource.timeSamples >= 1678260 && enemySpawn[48] == false){   //aprox. 16 segundos/705600
           enemies[48] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[48] = true;
        }
        if(audioSource.timeSamples >= 1700310 && enemySpawn[49] == false){   //aprox. 16.5 segundos/727650
           enemies[49] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[49] = true;
        }
        if(audioSource.timeSamples >= 1721110 && enemySpawn[50] == false){   //aprox. 17 segundos/749700
           enemies[50] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[50] = true;
        }
        if(audioSource.timeSamples >= 1744410 && enemySpawn[51] == false){   //aprox. 17.5 segundos/771750
           enemies[51] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[51] = true;
        }
        if(audioSource.timeSamples >= 1766460 && enemySpawn[52] == false){   //PRATOS!!!!!!
           enemies[52] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[52] = true;
        }
        if(audioSource.timeSamples >= 1786050 && enemySpawn[53] == false){   //aprox. 14 segundos/617400 
           enemies[53] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[53] = true;
        }
        if(audioSource.timeSamples >= 1810560 && enemySpawn[54] == false){   //aprox. 14.5 segundos/651450 
           enemies[54] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[54] = true;
        }
        if(audioSource.timeSamples >= 1830150 && enemySpawn[55] == false){   //aprox. 15.0 segundos/661500 
           enemies[55] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[55] = true;
        }
        if(audioSource.timeSamples >= 1853430 && enemySpawn[56] == false){   //aprox. 15.5 segundos/683550 
           enemies[56] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[56] = true;
        }
        if(audioSource.timeSamples >= 1876710 && enemySpawn[57] == false){   //aprox. 16 segundos/705600
           enemies[57] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[57] = true;
        }
        if(audioSource.timeSamples >= 1898760 && enemySpawn[58] == false){   //aprox. 16.5 segundos/727650
           enemies[58] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[58] = true;
        }
        if(audioSource.timeSamples >= 1918350 && enemySpawn[59] == false){   //aprox. 17 segundos/749700
           enemies[59] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[59] = true;
        }
        if(audioSource.timeSamples >= 1941630 && enemySpawn[60] == false){   //aprox. 18 segundos/793800
           enemies[60] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[60] = true;
        }
        if(audioSource.timeSamples >= 1962450 && enemySpawn[61] == false){   //aprox. 18.5 segundos/815850
           enemies[61] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[61] = true;
        }
         if(audioSource.timeSamples >= 1986960 && enemySpawn[62] == false){   //aprox. 19 segundos/837900
           enemies[62] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[62] = true;
        }
        if(audioSource.timeSamples >= 2006550 && enemySpawn[63] == false){   //aprox. 17.5 segundos/771750
           enemies[63] = Instantiate(enemyObject,new Vector3(movingDolly.transform.position.x+enemyOffsetX, enemyY, enemyZ), transform.rotation);
           enemySpawn[63] = true;
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
        if(audioSource.timeSamples >= 709363 && enemySpawn[0] == true){ //aprox. 16.083 segundos/709283
          enemyMove[0] = true;
        }
         if(audioSource.timeSamples >= 727238 && enemySpawn[1] == true){ //aprox. 16.5 segundos/727650
          enemyMove[1] = true;
        }
          if(audioSource.timeSamples >= 752639 && enemySpawn[2] == true){ //aprox. 17.055 segundos/752160
          enemyMove[2] = true;
        }
         if(audioSource.timeSamples >= 771455 && enemySpawn[3] == true){ //aprox. 17.5 segundos/771750
          enemyMove[3] = true;
        }
        if(audioSource.timeSamples >= 796857 && enemySpawn[4] == true){ //aprox. 18.055 segundos/796260
          enemyMove[4] = true;
        }
        if(audioSource.timeSamples >= 818495 && enemySpawn[5] == true){ //aprox. 18.555 segundos/818310
          enemyMove[5] = true;
        }
        if(audioSource.timeSamples >= 840134 && enemySpawn[6] == true){ //aprox. 19.055 segundos/840360
          enemyMove[6] = true;
        }
        if(audioSource.timeSamples >= 859891 && enemySpawn[7] == true){ //aprox. 19.5   segundos/859950
          enemyMove[7] = true;
        }
        if(audioSource.timeSamples >= 884351 && enemySpawn[8] == true){ //aprox. 20.057 segundos/884546
          enemyMove[8] = true;
        }
        if(audioSource.timeSamples >= 905990 && enemySpawn[9] == true){ //aprox. 20.527 segundos/905280
          enemyMove[9] = true;
        }
        if(audioSource.timeSamples >= 927628 && enemySpawn[10] == true){ //aprox. 21.027 segundos/927330
          enemyMove[10] = true;
        }
        if(audioSource.timeSamples >= 950610 && enemySpawn[11] == true){ //aprox. 16.083 segundos/709283
          enemyMove[11] = true;
        }
         if(audioSource.timeSamples >= 972660 && enemySpawn[12] == true){ //aprox. 16.5 segundos/727650
          enemyMove[12] = true;
        }
          if(audioSource.timeSamples >= 992250 && enemySpawn[13] == true){ //aprox. 17.055 segundos/752160
          enemyMove[13] = true;
        }
         if(audioSource.timeSamples >= 1016760 && enemySpawn[14] == true){ //aprox. 17.5 segundos/771750
          enemyMove[14] = true;
        }
        if(audioSource.timeSamples >= 1036350 && enemySpawn[15] == true){ //aprox. 18.055 segundos/796260
          enemyMove[15] = true;
        }
        if(audioSource.timeSamples >= 1060860 && enemySpawn[16] == true){ //aprox. 18.555 segundos/818310
          enemyMove[16] = true;
        }
        if(audioSource.timeSamples >= 1082910 && enemySpawn[17] == true){ //aprox. 19.055 segundos/840360
          enemyMove[17] = true;
        }
        if(audioSource.timeSamples >= 1106189 && enemySpawn[18] == true){ //aprox. 19.5   segundos/859950
          enemyMove[18] = true;
        }
        if(audioSource.timeSamples >= 1127010 && enemySpawn[19] == true){ //aprox. 20.057 segundos/884546
          enemyMove[19] = true;
        }
        if(audioSource.timeSamples >= 1149060 && enemySpawn[20] == true){ //aprox. 20.527 segundos/905280
          enemyMove[20] = true;
        }
        if(audioSource.timeSamples >= 1171110 && enemySpawn[21] == true){ //aprox. 21.027 segundos/927330
          enemyMove[21] = true;
        }
        if(audioSource.timeSamples >= 1193160 && enemySpawn[22] == true){ //aprox. 16.083 segundos/709283
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
        if(audioSource.timeSamples >= 2097210 && enemySpawn[63] == true){ //aprox. 20.057 segundos/884546
          enemyMove[63] = true;
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


