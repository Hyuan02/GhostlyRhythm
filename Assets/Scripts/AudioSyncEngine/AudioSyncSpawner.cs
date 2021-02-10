using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncSpawner : AudioSyncer
{

    public GameObject enemyObject;
    float[] Ypos = new float[] { 3f, 0, -3F };
    [SerializeField]
    float enemyX = 0;
    float enemyY = 0;
    float enemyZ = 2f;



    public override void OnBeat()
    {
        base.OnBeat();
        enemyY = Ypos[Random.Range(0, 3)];
        Instantiate(enemyObject, new Vector3(transform.position.x, enemyY, enemyZ), transform.rotation);
    }


}
