using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWatcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Game Over");
        if (collision.CompareTag("Enemy"))
        {
            
            GameManager.instance.CallGameOver();
            this.gameObject.SetActive(false);
        }
    }
}
