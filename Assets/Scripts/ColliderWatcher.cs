using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderWatcher : MonoBehaviour
{
	
	
	

	public void LoseStar()
	{
		//Diminui o numero de estrelas
		GameManager.instance.starsRemaining--;

        //Trocar sprite da estrela perdida
        GameManager.instance.LoseStar();

		//Se perder todas as estrelas, fim de jogo.
		if(GameManager.instance.starsRemaining <= 0)
		{
			GameManager.instance.CallGameOver();
            this.gameObject.SetActive(false);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Game Over");
        if (collision.CompareTag("Enemy"))
        {
            LoseStar();
        }
    }
}
