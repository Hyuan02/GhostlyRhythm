using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncSpawner : AudioSyncer
{

    public GameObject enemyObject;

    [SerializeField]
    private GameObject movingDolly = null;

    [SerializeField]
    private GameObject[] trailsObject = { }; 
    float[] Ypos = new float[] { 3f, 0, -3F };
    [SerializeField]
    float enemyX = 0;
    float enemyZ = 2f;

    public override void OnBeat()
    {
        base.OnBeat();
        var enemyY = trailsObject[Random.Range(0, trailsObject.Length)].transform.position.y;
        var newEnemyObject = Instantiate(enemyObject, this.transform);
        newEnemyObject.transform.position = new Vector3(movingDolly.transform.position.x + enemyX, enemyY, enemyZ);
    }



}
