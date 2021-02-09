using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
         void OnBecameInvisible() {
             Destroy(gameObject);
         }
}
