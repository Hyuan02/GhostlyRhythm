using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    void OnBecameInvisible() {
       // Debug.Log("Score! ");
        GameManager.instance.IncrementScore();
        Destroy(gameObject);
    }
}
