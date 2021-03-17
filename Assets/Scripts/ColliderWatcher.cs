using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderWatcher : MonoBehaviour
{
	public Sprite ActiveStar;
	public Sprite InactiveStar;
	public Image[] stars;
	public int starsRemaining;

	public void LoseStar()
	{
		//Diminui o numero de estrelas
		starsRemaining--;

		//Trocar sprite da estrela perdida
		stars[starsRemaining].sprite = InactiveStar;

		//Se perder todas as estrelas, fim de jogo.
		if(starsRemaining == 0)
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
